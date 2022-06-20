using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    public class AssetSensor
    {
        public int AssetId { get; set; }


        public int SensorId { get; set; }


        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        public Asset? Asset { get; set; }


        //[JsonIgnore]
        //[JsonProperty(Required = Required.Default)]
        public Sensor? Sensor { get; set; }
    }
}
