using AutoMapper;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("export-data")]
        public async Task<IActionResult> ExportExcel()
        {
            using (var package = new ExcelPackage())
            {
                await AddSheetAsync(
                    package,
                    "Bookings",
                    async () => _mapper.Map<BookingDTO[]>(await _unitOfWork.Bookings.GetAllAsync())
                );

                await AddSheetAsync(
                    package,
                    "AppUsers",
                    async () => _mapper.Map<AppUserDTO[]>(await _unitOfWork.Users.GetAllUsersAsync())
                );

                await AddSheetAsync(
                    package,
                    "Orders",
                    async () => _mapper.Map<OrderDTO[]>(await _unitOfWork.Orders.GetAllOrdersAsync())
                );

                await AddSheetAsync(
                    package,
                    "Rooms",
                    async () => _mapper.Map<RoomDTO[]>(await _unitOfWork.Rooms.GetAllAsync())
                );

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "ExportData.xlsx";

                return File(stream, contentType, fileName);
            }
        }

        private async Task AddSheetAsync<T>(ExcelPackage package, string sheetName, Func<Task<T[]>> getData)
        {
            var worksheet = package.Workbook.Worksheets.Add(sheetName);
            var data = await getData();

            // Load data into the worksheet, including headers
            worksheet.Cells["A1"].LoadFromCollection(data, true);

            // Format DateTime cells if necessary
            var dateTimeProperties = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
                .Select(p => p.Name)
                .ToArray();

            for (int i = 0; i < dateTimeProperties.Length; i++)
            {
                int colIndex = Array.IndexOf(data[0].GetType().GetProperties().Select(p => p.Name).ToArray(), dateTimeProperties[i]) + 1;
                worksheet.Column(colIndex).Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
            }

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
        }

        [HttpGet("export-orders-by-user/{userId}")]
        public async Task<IActionResult> ExportOrdersByUserIdToExcel(Guid userId)
        {
            using (var package = new ExcelPackage())
            {
                await AddOrdersByUserIdSheet(package, userId);

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = $"Orders_{userId}.xlsx";

                return File(stream, contentType, fileName);
            }
        }

        [HttpGet("export-paymenthistory")]
        public async Task<IActionResult> ExportOrdersToExcel()
        {
            using (var package = new ExcelPackage())
            {
                await AddPaymentSheet(package);

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "PaymentHistory.xlsx";

                return File(stream, contentType, fileName);
            }
        }

        private async Task AddPaymentSheet(ExcelPackage package)
        {
            var orders = await _unitOfWork.Orders.GetAllOrdersAsync();
            var orderDtos = _mapper.Map<OrderDTO[]>(orders);

            var worksheet = package.Workbook.Worksheets.Add("Orders");

            // Load data from the collection into the worksheet
            worksheet.Cells["A1"].LoadFromCollection(orderDtos, true);

            // Format the CreatedDate column
            var createdDateColumn = worksheet.Cells[2, 4, 2 + orderDtos.Length - 1, 4];
            createdDateColumn.Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
        }


        private async Task AddOrdersByUserIdSheet(ExcelPackage package, Guid userId)
        {
            var orders = await _unitOfWork.Orders.GetByUserIdAsync(userId);
            var orderDtos = _mapper.Map<OrderDTO[]>(orders);

            var worksheet = package.Workbook.Worksheets.Add("Orders");

            // Load data from the collection into the worksheet
            worksheet.Cells["A1"].LoadFromCollection(orderDtos, true);

            // Format the CreatedDate column
            var createdDateColumn = worksheet.Cells[2, 4, 2 + orderDtos.Length - 1, 4];
            createdDateColumn.Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";

            // Auto-fit columns 
            worksheet.Cells.AutoFitColumns();
        }
    }
}
