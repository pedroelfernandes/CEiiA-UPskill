﻿using MainAPI.Models;

namespace MainAPI.DTO
{
    public class AssetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Company { get; set; }

        public string? Location { get; set; }

        public DateTime? CreationDate { get; set; }

        public int AssetTypeId { get; set; }

        public bool Active { get; set; }

        public ICollection<AssetSensor>? Sensors { get; set; }

        public static AssetDTO ToDto(Asset asset)
        {
            return new AssetDTO()
            {
                Id = asset.Id,
                Name = asset.Name,
                Company = asset.Company,
                Location = asset.Location,
                CreationDate = asset.CreationDate,
                AssetTypeId = asset.AssetTypeId,
                Active = asset.Active,
            };
        }
    }
}