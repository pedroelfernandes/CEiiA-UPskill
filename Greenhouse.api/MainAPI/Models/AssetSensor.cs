using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{

    public class AssetSensor
    {

        public int AssetId { get; set; }

        public int SensorId { get; set; }


        public Asset? Asset { get; set; }
        public Sensor? Sensor { get; set; }

    }
}
