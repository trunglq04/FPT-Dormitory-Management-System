using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Dorm
        [HttpGet]
        public async Task<IActionResult> GetAllDorms()
        {
            var dorms = await _unitOfWork.Dorms.GetAllAsync();
            return Ok(dorms);
        }

        // GET: api/Dorm/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDormById(Guid id)
        {
            var dorm = await _unitOfWork.Dorms.GetByIdAsync(id);
            if (dorm == null)
                return NotFound();

            return Ok(dorm);
        }
    }
}
