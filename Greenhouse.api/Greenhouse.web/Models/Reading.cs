
namespace Greenhouse.web.Models
{
    public class Reading
    {
        private string id = string.Empty;
        public string Id { get => id; set => id = value.ToString(); }

        public string SensorId { get; set; } = null!;
       
        public string SensorType { get; set; } = null!;
        public DateTime ReadDate { get; set; }

        public string Value { get; set; }
        public string ReadingUnit { get; set; } = null!;



        public static async Task<IEnumerable<Reading>> GetReadings(string uri)
        {
            IEnumerable<Reading> readings = new List<Reading>();

            HttpClient client = Helpers.Helpers.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync("Readings/GetLast/");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                {
                    readings = res;
                }
            }

            return readings;
        }
    }

    
}
