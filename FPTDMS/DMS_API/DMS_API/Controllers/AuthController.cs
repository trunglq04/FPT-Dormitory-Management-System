using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DMS_API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
        {
            var user = new AppUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return BadRequest(ModelState);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            _logger.LogInformation("Login attempt for user: {Email}", model.Email);

            // Support both Email and Username for login
            var user = await _userManager.FindByEmailAsync(model.Email) ?? await _userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                _logger.LogWarning("User not found: {Email}", model.Email);
                return Unauthorized(new { Error = "Invalid username or password" });    // Status code 401
            }

            // Changed to verify the password manually
            _logger.LogInformation("User found: {Email}", model.Email);
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
            {
                _logger.LogWarning("Invalid password for user: {Email}", model.Email);
                return Unauthorized(new { Error = "Invalid username or password" });    // Status code 401
            }

            _logger.LogInformation("Password verified for user: {Email}", model.Email);
            var token = GenerateJwtToken(user);
            return Ok(new { access_token = token });
        }

        private string GenerateJwtToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]?? string.Empty));
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
    }
}
