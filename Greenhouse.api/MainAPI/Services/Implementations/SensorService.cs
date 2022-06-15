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


        public async Task<SensorDTO> Create(Sensor sensor)
        {
            SensorDTO sensorDTO = SensorDTO.ToDto(await _sensorRepository.Create(sensor));

            //sensorDTO.SensorType = (await _sensorTypeService.Get(sensorDTO.SensorTypeId));

            return sensorDTO;
        }


        public async Task<SensorDTO> Get(int id) =>
            SensorDTO.ToDto(await _sensorRepository.Get(id));


        public async Task<bool> ChangeState(int id) =>
            await _sensorRepository.ChangeState(id);


        public async Task<SensorDTO> Edit(int id, string name, string description,
            string unit, int urlId, string company, int sensorTypeId)
        {
            SensorDTO tempSensor = SensorDTO.ToDto(await _sensorRepository.Edit(id, name, description, unit, urlId, company, sensorTypeId));

            //tempSensor.SensorType = await _sensorTypeService.Get(tempSensor.SensorTypeId);

            return tempSensor;
        }


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
    }
}
