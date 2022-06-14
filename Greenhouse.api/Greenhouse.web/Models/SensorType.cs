﻿
namespace Greenhouse.web.Models
{
    public class SensorType
    {
        public int Id {get; set;}

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}