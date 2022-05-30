﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    public class Asset
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Company { get; set; }

        public string? Location { get; set; }

        public DateTime? CreationDate { get; set; }

        [ForeignKey("AssetType")]
        public AssetType? AssetType { get; set; }

    }
}