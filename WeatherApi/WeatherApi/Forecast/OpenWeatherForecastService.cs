using RestSharp;
using System.Configuration;
using WeatherApi.Models;

namespace WeatherApi
{
    public class OpenWeatherForecastService : IForecastService
    {
        private string OpenWeatherApiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
        public Forecast GetForecast(decimal latitude, decimal longitude)
        {            
            var client = new RestClient("http://api.openweathermap.org");

            var request = new RestRequest($"data/2.5/weather?lat={latitude}&lon={longitude}&APPID={OpenWeatherApiKey}&units=metric", Method.GET);

            var openWeatherResponse = client.Execute<OpenWeatherResponse>(request).Data;

            return new Forecast { 
                Name = openWeatherResponse.Name, 
                Temperature = openWeatherResponse.Main.Temp,
                MaxTemperature = openWeatherResponse.Main.Temp_max,
                MinTemperature = openWeatherResponse.Main.Temp_min,
                Humidity = openWeatherResponse.Main.Humidity
            };
        }
    }

    public class OpenWeatherResponse
    {
        public string Name { get; set; }
        public OpenWeatherResponseMain Main { get; set; }
    }

    public class OpenWeatherResponseMain
    {
        public decimal Temp { get; set; }
        public decimal Temp_min { get; set; }
        public decimal Temp_max { get; set; }
        public decimal Humidity { get; set; }
    }
}