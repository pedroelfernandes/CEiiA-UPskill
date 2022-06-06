﻿using MainAPI.DTO;
using System.ComponentModel.DataAnnotations;

namespace MainAPI.Models
{
    public class AssetTypeId
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public bool Active { get; set; }

        public static AssetTypeDTO ToDto(AssetTypeId assetType)
        {
            return new AssetTypeDTO()
            {
                Id = assetType.Id,
                Name = assetType.Name,
                Description = assetType.Description,
                Active = assetType.Active,
            };
        }
    }
}
