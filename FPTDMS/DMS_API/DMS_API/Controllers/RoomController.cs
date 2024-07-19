using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _unitOfWork.Rooms.GetAllAsync();
            var roomDTOs = _mapper.Map<List<RoomDTO>>(rooms);
            return Ok(roomDTOs);
        }

        // GET: api/Room/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
                return NotFound();

            var roomDTO = _mapper.Map<RoomDTO>(room);
            return Ok(roomDTO);
        }
        //PUT: api/Room/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(Guid id, UpdateRoomRequestDTO room)
        {
            try
            {
                await _unitOfWork.Rooms.UpdateAsync(id, room);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        //POST: api/Room
        [HttpPost]
        public async Task<ActionResult<AddRoomRequestDTO>> AddRoom(AddRoomRequestDTO addRoomRequestDTO)
        {
            var room = _mapper.Map<Room>(addRoomRequestDTO);

            await _unitOfWork.Rooms.AddAsync(room);
            await _unitOfWork.SaveChanges();

            var roomDTO = _mapper.Map<RoomDTO>(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = roomDTO.Id }, roomDTO);
        }
        //DELETE: api/Room/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _unitOfWork.Rooms.Delete(room);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }
    }
}