using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface ILayerAPISensorService
    {
        Task<IReadOnlyList<Sensor>> GetSensors();


        Task<List<Sensor>> GetAPISensors(StoredURL storedURL);
    }
}
