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
            SensorTypeDTO sensorTypeDTO = new SensorTypeDTO();
            sensorTypeDTO.Name = sensorType.Name;

            await _sensorTypeRepository.Create(sensorType);
            return sensorTypeDTO;
        }

        public async Task<SensorTypeDTO> Get(int id)
        {
            SensorType sensorTypeDto = await _sensorTypeRepository.Get(id);
            return SensorTypeDTO.ToDto(sensorTypeDto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _sensorTypeRepository.Delete(id);
        }

        public async Task<SensorTypeDTO> Edit(SensorType sensorType)
        {

            SensorType sensorTypeDto = await _sensorTypeRepository.Edit(sensorType);

            return SensorTypeDTO.ToDto(sensorTypeDto);
        }

    }
}
