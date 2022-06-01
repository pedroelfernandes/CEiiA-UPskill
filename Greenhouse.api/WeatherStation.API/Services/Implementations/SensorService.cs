using WeatherStation.api.DTOs;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Interface;
using WeatherStation.api.Services.Interfaces;

namespace WeatherStation.api.Services.Implementations
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

            return sensors.Select(s => SensorDTO.ToDto(s)).ToList();
        }
    }
}
