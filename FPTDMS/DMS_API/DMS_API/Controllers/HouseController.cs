using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HouseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //GET all houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetAllHouses()
        {
            var houses = await _unitOfWork.Houses.GetAllAsync();
            var houseDTOs = _mapper.Map<List<HouseDTO>>(houses);
            return Ok(houseDTOs);
        }

        //GET house by id
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDTO>> GetHouseById(Guid id)
        {
            var house = await _unitOfWork.Houses.GetByIdAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            var houseDTO = _mapper.Map<HouseDTO>(house);
            return Ok(houseDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AddHouseRequestDTO>> AddHouse(AddHouseRequestDTO addHouseRequest)
        {
            var house = _mapper.Map<House>(addHouseRequest);

            await _unitOfWork.Houses.AddAsync(house);
            await _unitOfWork.SaveChanges();

            var houseDTO = _mapper.Map<HouseDTO>(house);
            return CreatedAtAction(nameof(GetHouseById), new { id = houseDTO.Id }, houseDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHouse(Guid id)
        {
            var house = await _unitOfWork.Houses.GetByIdAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _unitOfWork.Houses.Delete(house);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHouse(Guid id, UpdateHouseRequestDTO updateRequest)
        {
            try
            {
                await _unitOfWork.Houses.UpdateAsync(id, updateRequest);
                await _unitOfWork.SaveChanges();

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("House not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}