using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface ISensorServices
    {
        Task<IEnumerable<Sensor>> GetSensors();
        //Task<AssetType> GetAssetTypeById(int Id);
        Task<Sensor> Create(Sensor sensor);
        //Task<AssetType> EditAssetType(int id, string name, string description, bool active);
        //Task<bool> ChangeStateAssetType(int Id);
    }
}
