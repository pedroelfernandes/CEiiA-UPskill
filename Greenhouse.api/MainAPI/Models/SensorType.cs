﻿using System.ComponentModel.DataAnnotations;

namespace MainAPI.Models
{
    public class SensorType
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
