using AutoMapper;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserIdAsync(Guid userId)
        {
            var orders = await _unitOfWork.Orders.GetByUserIdAsync(userId);
            if (orders == null)
            {
                return NotFound();
            }

            var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync() // Add this method
        {
            var orders = await _unitOfWork.Orders.GetAllOrdersAsync();
            if (orders == null)
            {
                return NotFound();
            }

            var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }
    }
}