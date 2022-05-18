﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    [NotMapped]
    public class StoredURL
    {
        public string? Id { get; set; }


        public string? Url { get; set; }
    }
}
