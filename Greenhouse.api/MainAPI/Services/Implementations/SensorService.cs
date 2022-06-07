using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;


        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }


        public async Task<SensorDTO> Create(Sensor sensor)
        {
            Sensor tempSensor = await _sensorRepository.Create(sensor);

            return SensorDTO.ToDto(tempSensor);
        }


        public async Task<SensorDTO> Get(int id)
        {
            Sensor tempSensor = await _sensorRepository.Get(id);

            return SensorDTO.ToDto(tempSensor);
        }


        public async Task<bool> ChangeState(int id) =>
            await _sensorRepository.ChangeState(id);


        public async Task<SensorDTO> Edit(int id, string name, string description,
            string unit, int urlId, string company, int sensorTypeId)
        {
            Sensor tempSensor = await _sensorRepository.Edit(id, name, description, unit, urlId, company, sensorTypeId);

            return SensorDTO.ToDto(tempSensor);
        }
    }
}
