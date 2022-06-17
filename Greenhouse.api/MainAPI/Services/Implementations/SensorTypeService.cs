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

        public async Task<List<SensorTypeDTO>> Get()
        {
            List<SensorType> sensorTypes = await _sensorTypeRepository.Get();
            return sensorTypes.Select(u => SensorTypeDTO.ToDto(u)).ToList();
        }


        public async Task<SensorTypeDTO> GetSensorTypeById(int id)
        {
            SensorType tempSensorType = await _sensorTypeRepository.GetSensorTypeById(id);
            return SensorTypeDTO.ToDto(tempSensorType);
        }

        public async Task<bool> ChangeState(int id)
        {
            return await _sensorTypeRepository.ChangeState(id);
        }

        public async Task<SensorTypeDTO> Edit(SensorType sensorType)
        {

            SensorType tempSensorType = await _sensorTypeRepository.Edit(sensorType);

            return SensorTypeDTO.ToDto(tempSensorType);
        }

    }
}
