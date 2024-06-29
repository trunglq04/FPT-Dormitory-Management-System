using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        //[Authorize("api")]
        public async Task<ActionResult<IEnumerable<AppUserDTO>>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync();

            if (users == null)
                return NotFound();

            var userDTOs = _mapper.Map<List<AppUserDTO>>(users);
            return Ok(userDTOs);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDTO>> GetUserById(Guid id)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var userDTOs = _mapper.Map<AppUserDTO>(user);
            return Ok(user);
        }

        [HttpPost("{id}")]
        [Authorize("api")]
        public async Task<ActionResult> UpdateUserAsync(Guid id, UpdateUserRequestDTO updateUser)
        {
            await _unitOfWork.Users.UpdateUserAsync(id, updateUser);
            return Ok("Succesfully Update User!");
        }
    }
}
