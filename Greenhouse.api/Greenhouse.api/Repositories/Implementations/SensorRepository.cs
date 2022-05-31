using Greenhouse.api.Models;
using Greenhouse.api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Greenhouse.api.Repositories.Implementations
{
    public class SensorRepository : ISensorRepository
    {
        private readonly IMongoCollection<Sensor> _sensorsCollection;


        public SensorRepository(IOptions<GreenhouseDatabaseSettings> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _sensorsCollection = mongoDatabase.GetCollection<Sensor>("Sensors");
        }


        public async Task<Sensor> GetSensorById(string id) =>
            await _sensorsCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }
}
