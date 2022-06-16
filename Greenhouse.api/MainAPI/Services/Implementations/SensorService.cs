using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly ILayerAPISensorService _layerAPISensorService;
        private readonly ISensorTypeService _sensorTypeService;


        public SensorService(ISensorRepository sensorRepository, ILayerAPISensorService layerAPISensorService, ISensorTypeService sensorTypeService)
        {
            _sensorRepository = sensorRepository;
            _layerAPISensorService = layerAPISensorService;
            _sensorTypeService = sensorTypeService;
        }


        public async Task<SensorDTO> Create(Sensor sensor) =>
            SensorDTO.ToDto(await _sensorRepository.Create(sensor));


        public async Task<SensorDTO> Get(int id) =>
            SensorDTO.ToDto(await _sensorRepository.Get(id));


        public async Task<bool> ChangeState(int id) =>
            await _sensorRepository.ChangeState(id);


        public async Task<SensorDTO> Edit(Sensor sensor) =>
            SensorDTO.ToDto(await _sensorRepository.Edit(sensor));


        public async Task<bool> CheckForNewSensors()
        {
            bool updatedDb = false;
            IReadOnlyList<Sensor> sensors = await _layerAPISensorService.GetSensors();

            foreach (Sensor sensor in sensors)
            {
                if (!_sensorRepository.FindInDb(sensor))
                {
                    await _sensorRepository.Create(sensor);
                    updatedDb = true;
                }
            }

            return updatedDb;
        }


        public async Task<bool> CheckForGenericSensors() =>
            await _sensorRepository.CheckForGenericSensors();
    }
}
