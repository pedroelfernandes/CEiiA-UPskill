using MainAPI.Models;

namespace MainAPI.DTO
{
    public class AssetTypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

        public static AssetTypeDTO ToDto(AssetType assetType)
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
