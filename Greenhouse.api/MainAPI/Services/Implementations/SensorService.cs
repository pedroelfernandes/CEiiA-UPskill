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
        private readonly ISensorTypeRepository _sensorTypeRepository;


        public SensorService(ISensorRepository sensorRepository, ILayerAPISensorService layerAPISensorService, ISensorTypeService sensorTypeService, ISensorTypeRepository sensorTypeRepository)
        {
            _sensorRepository = sensorRepository;
            _layerAPISensorService = layerAPISensorService;
            _sensorTypeService = sensorTypeService;
            _sensorTypeRepository = sensorTypeRepository;
        }


        public async Task<SensorDTO> Create(Sensor sensor) =>
            SensorDTO.ToDto(await _sensorRepository.Create(sensor));


        public async Task<List<SensorDTO>> Get() =>
            (await _sensorRepository.Get()).Select(s => SensorDTO.ToDto(s)).ToList();


        public async Task<SensorDTO> GetSensor(int id) =>
            SensorDTO.ToDto(await _sensorRepository.GetSensor(id));


        public async Task<bool> ChangeState(int id) =>
            await _sensorRepository.ChangeState(id);


        public async Task<SensorDTO> Edit(SensorDTO sensorDTO) =>
            SensorDTO.ToDto(await _sensorRepository.Edit(new Sensor
            {
                Id = sensorDTO.Id,
                Name = sensorDTO.Name,
                Description = sensorDTO.Description,
                Unit = sensorDTO.Unit,
                Company = sensorDTO.Company,
                SensorTypeId = sensorDTO.SensorTypeId,
                SensorType = new SensorType
                {
                    Id = sensorDTO.SensorTypeId
                }
            }));
            


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
