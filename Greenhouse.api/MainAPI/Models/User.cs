﻿using System.ComponentModel.DataAnnotations;

namespace MainAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        
        [Required]
        public string? Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}