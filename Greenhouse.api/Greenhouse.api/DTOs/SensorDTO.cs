﻿using Greenhouse.api.Models;

namespace Greenhouse.api.DTOs
{
    public class SensorDTO
    {
        public string? SensorId { get; set; }


        public string? SensorType { get; set; }


        public static SensorDTO ToDto(Reading reading)
        {
            return new SensorDTO()
            {
                SensorId = reading.SensorId,
                SensorType = reading.SensorType
            };
        }
    }
}