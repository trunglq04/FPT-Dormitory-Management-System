using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FloorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //GET all floor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorDTO>>> GetAllFloors()
        {
            var floors = await _unitOfWork.Floors.GetAllAsync();
            var floorDTOs = _mapper.Map<List<FloorDTO>>(floors);
            return Ok(floorDTOs);
        }

        //GET floor by id
        [HttpGet("{id}")]
        public async Task<ActionResult<FloorDTO>> GetFloorbyId(Guid id)
        {
            var floor = await _unitOfWork.Floors.GetByIdAsync(id);
            if (floor == null)
            {
                return NotFound();
            }
            var floorDTO = _mapper.Map<FloorDTO>(floor);
            return Ok(floorDTO);
        }
        //ADD new floor
        [HttpPost]
        public async Task<ActionResult<AddFloorRequestDTO>> AddFloor(AddFloorRequestDTO addFloorRequest)
        {
            var floor = _mapper.Map<Floor>(addFloorRequest);

            await _unitOfWork.Floors.AddAsync(floor);
            await _unitOfWork.SaveChanges();

            var floorDTO = _mapper.Map<FloorDTO>(floor);
            return CreatedAtAction(nameof(GetFloorbyId), new { id = floorDTO.Id }, floorDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFloor(Guid id, UpdateFloorRequestDTO updateRequest)
        {
            try
            {
                await _unitOfWork.Floors.UpdateAsync(id, updateRequest);
                await _unitOfWork.SaveChanges();

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Floor not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Delete floor by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloor(Guid id)
        {
            var floor = await _unitOfWork.Floors.GetByIdAsync(id);
            if (floor == null)
            {
                return NotFound();
            }

            _unitOfWork.Floors.Delete(floor);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }
    }
}