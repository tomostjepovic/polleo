using WeatherApi.Models;

namespace WeatherApi
{
    public interface IForecastService
    {
        Forecast GetForecast(decimal latitude, decimal longitude);
    }
}
