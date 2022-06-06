using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class SensorTypeService : ISensorTypeService
    {
        private readonly ISensorTypeRepository _sensorTypeRepository;

        public SensorTypeService(ISensorTypeRepository sensorTypeRepository)
        {
            _sensorTypeRepository = sensorTypeRepository;
        }

        public async Task<SensorTypeDTO> Create(SensorType sensorType)
        {
            SensorType tempSensorType = await _sensorTypeRepository.Create(sensorType);
            return SensorTypeDTO.ToDto(tempSensorType);
        }

        public async Task<SensorTypeDTO> Get(int id)
        {
            SensorType tempSensorType = await _sensorTypeRepository.Get(id);
            return SensorTypeDTO.ToDto(tempSensorType);
        }

        public async Task<bool> ChangeState(int id)
        {
            return await _sensorTypeRepository.ChangeState(id);
        }

        public async Task<SensorTypeDTO> Edit(int id, string name, string description)
        {

            SensorType tempSensorType = await _sensorTypeRepository.Edit(id, name, description);

            return SensorTypeDTO.ToDto(tempSensorType);
        }

    }
}
