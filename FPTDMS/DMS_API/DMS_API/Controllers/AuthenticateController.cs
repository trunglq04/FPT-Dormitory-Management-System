﻿using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using DMS_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace DMS_API.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public AuthenticateController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration configuration, ILogger<AuthenticateController> logger, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            var roleName = "Client";

            if (!Regex.IsMatch(model.Email, emailPattern))
                ModelState.AddModelError("erros", "Invalid email format");
            // ADD: Check password strength
            var userName = model.Email.Split('@')[0];
            

            var user = new AppUser()
            { 
                UserName = userName, 
                Email = model.Email,
                Balance = new Balance { Amount = 0 },
                LockoutEnabled = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
                return Ok(new { Message = "User registered successfully", UserId = user.Id });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("erros", error.Description);
            }
            return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user);
                bool isLockoutEnd = lockoutEndDate == null || lockoutEndDate < DateTimeOffset.Now;

                if (await _userManager.CheckPasswordAsync(user, model.Password) && isLockoutEnd)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    string? fullName = null;
                    if (user.FirstName != null || user.LastName != null)
                    {
                        fullName = user.FirstName + " " + user.LastName;
                    }

                    var authClaims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, fullName ?? user.UserName!),
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? string.Empty));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddMinutes(45),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                    var refreshToken = new RefreshToken
                    {
                        Id = Guid.NewGuid(),
                        Token = Guid.NewGuid().ToString(),
                        UserId = user.Id,
                        ExpiryDate = DateTime.UtcNow.AddDays(1),
                        IsRevoked = false
                    };

                    return Ok(new
                    {
                        user_id = user.Id, // Include the user ID in the response
                        access_token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        refresh_token = refreshToken.Token,
                    });
                }
                else if (user.LockoutEnabled == true)
                {
                    user.AccessFailedCount++;
                    return await addLockoutEnd(user);
                }
            }
            return Unauthorized("Please check your Email or Password");
        }


        //Forgot password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            // Generate OTP (One-Time Password)
            var otp = new Random().Next(100000, 999999).ToString(); // Example: Generate a 6-digit OTP
            var expirationTime = DateTime.UtcNow.AddMinutes(5); // OTP expires in 15 minutes

            // Save OTP and expiration time to database or in-memory cache
            // Example: user.OTP = otp; user.OTPExpirationTime = expirationTime; await _userManager.UpdateAsync(user);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Send OTP via email
            await _emailService.SendEmailAsync(model.Email, 
                "Reset Password OTP", $"Your OTP for password reset is {otp}.");

            return Ok("OTP has been sent to your email.");
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPasswordRequestDTO { Token = token, Email = email };
            return Ok(new { model });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            // Check if OTP is valid and not expired
            // Example: if (user.OTP != model.Otp || user.OTPExpirationTime < DateTime.UtcNow)
            // {
            //     return BadRequest("Invalid or expired OTP");
            // }

            // Generate password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return Ok(new { token });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok("Password has been reset successfully.");
        }

        private string GenerateJwtToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"] ?? string.Empty));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IActionResult> addLockoutEnd(AppUser user)
        {
            var accessFailedCount = user.AccessFailedCount;
            if (accessFailedCount < 3)
            {
                return Unauthorized("Please check your Email or Password again!");
            }
            if (accessFailedCount == 3)
            {
                var lockoutEnd = DateTimeOffset.Now.AddMinutes(5);
                await _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
                return Unauthorized($"You attempts fail {accessFailedCount}, your account is locked 5 minutes");
            }
            else if (accessFailedCount == 5)
            {
                var lockoutEnd = DateTimeOffset.Now.AddMinutes(10);
                await _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
                return Unauthorized($"You attempts fail {accessFailedCount}, your account is locked 10 minutes");
            }
            else 
            {
                var lockoutEnd = DateTimeOffset.Now.AddMinutes(15);
                await _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
                return Unauthorized($"You attempts fail {accessFailedCount}, your account is locked 15 minutes");
            }
        }

    }
}