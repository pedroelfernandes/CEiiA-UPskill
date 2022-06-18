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


        public async Task<SensorTypeDTO> Create(SensorType sensorType) =>
            SensorTypeDTO.ToDto(await _sensorTypeRepository.Create(sensorType));


        public async Task<bool> ChangeState(int id) =>
            await _sensorTypeRepository.ChangeState(id);


        public async Task<SensorTypeDTO> Edit(SensorType sensorType) =>
            SensorTypeDTO.ToDto(await _sensorTypeRepository.Edit(sensorType));
    }
}
