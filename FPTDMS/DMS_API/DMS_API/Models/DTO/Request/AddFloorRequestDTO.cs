﻿namespace DMS_API.Models.DTO.Request
{
    public class AddFloorRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Type { get; set; }
        public Guid DormId { get; set; }
    }
}
