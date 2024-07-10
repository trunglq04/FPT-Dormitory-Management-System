using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;


namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DormController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Dorm
        [HttpGet]
        public async Task<IActionResult> GetAllDorms()
        {
            var dorms = await _unitOfWork.Dorms.GetAllAsync();
            var dormDTOs = _mapper.Map<List<DormDTO>>(dorms);
            return Ok(dormDTOs);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDorm(DormDTO dormDTO)
        {
            var dorm = _mapper.Map<Dorm>(dormDTO);
            await _unitOfWork.Dorms.AddAsync(dorm);
            await _unitOfWork.SaveChanges();
            return Ok(dormDTO);
        }


        // GET: api/Dorm/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDormById(Guid id)
        {
            var dorm = await _unitOfWork.Dorms.GetByIdAsync(id);
            if (dorm == null)
                return NotFound();

            var dormDTO = _mapper.Map<DormDTO>(dorm);
            return Ok(dormDTO);
        }
    }
}
