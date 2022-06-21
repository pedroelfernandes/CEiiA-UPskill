using MainAPI.Models;
using Newtonsoft.Json;

namespace MainAPI.DTO
{
    public class AssetDTO
    {
        public int Id { get; set; }


        public string? Name { get; set; }


        public string? Description { get; set; }


        public string? Company { get; set; }


        public string? Location { get; set; }


        public DateTime? CreationDate { get; set; }


        public int AssetTypeId { get; set; }


        public AssetTypeDTO? AssetType { get; set; }


        public bool IsActive { get; set; }


        public List<SensorDTO>? Sensors { get; set; }


        public static AssetDTO ToDto(Asset asset)
        {
            List<Sensor> sensors = asset.Sensors.ToList().Select(s => s.Sensor).ToList(); 

            return new AssetDTO()
            {
                Id = asset.Id,
                Name = asset.Name,
                Description = asset.Description,
                Company = asset.Company,
                Location = asset.Location,
                CreationDate = asset.CreationDate,
                AssetTypeId = asset.AssetTypeId,
                AssetType = AssetTypeDTO.ToDto(asset.AssetType),
                IsActive = asset.IsActive,
                Sensors = sensors.Select(s => SensorDTO.ToDto(s)).ToList()
            };
        }
    }
}
