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
            SensorDTO sensorDTO = new SensorDTO();
            sensorDTO.Name = sensor.Name;

            await _sensorRepository.Create(sensor);
            return sensorDTO;
        }

        public async Task<SensorDTO> Get(int id)
        {
            Sensor sensorDto = await _sensorRepository.Get(id);
            return SensorDTO.ToDto(sensorDto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _sensorRepository.Delete(id);
        }

        public async Task<SensorDTO> Edit(Sensor sensor)
        {

            Sensor sensorDto = await _sensorRepository.Edit(sensor);

            return SensorDTO.ToDto(sensorDto);
        }

    }
}
