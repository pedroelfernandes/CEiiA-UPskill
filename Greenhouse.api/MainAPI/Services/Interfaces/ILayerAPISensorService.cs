using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface ILayerAPISensorService
    {
        Task<IReadOnlyList<LayerSensor>> GetSensors();
    }
}
