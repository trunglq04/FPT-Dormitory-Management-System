using AutoMapper;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllRooms()
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync();
            var userDTOs = _mapper.Map<List<AppUserDTO>>(users);
            return Ok(userDTOs);
        }
    }
}
