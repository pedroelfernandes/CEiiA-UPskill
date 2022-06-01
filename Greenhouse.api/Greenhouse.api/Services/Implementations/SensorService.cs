using Greenhouse.api.DTOs;
using Greenhouse.api.Models;
using Greenhouse.api.Repositories.Interfaces;
using Greenhouse.api.Services.Interfaces;

namespace Greenhouse.api.Services.Implementations
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;


        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }


        public async Task<SensorDTO> GetSensorById(string id)
        {
            Sensor sensor = await _sensorRepository.GetSensorById(id);

            return SensorDTO.ToDto(sensor);
        }


        public async Task<IReadOnlyList<SensorDTO>> GetAllSensors()
        {
            IReadOnlyList<Sensor> sensors = await _sensorRepository.GetAllSensors();

            return sensors.Select(sensor => SensorDTO.ToDto(sensor)).ToList();
        }
    }
}
