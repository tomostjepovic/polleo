namespace WeatherApi.Models
{
    public class Forecast
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal MaxTemperature { get; set; }
        public decimal MinTemperature { get; set; }
    }
}