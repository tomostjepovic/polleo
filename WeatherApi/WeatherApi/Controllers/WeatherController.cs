using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApi.Helpers;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private IForecastService _forecastService;

        public WeatherController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        // GET api/weather?latitude=10&longitude=20
        [HttpGet]
        [Route("weather-forecast")]
        public IHttpActionResult Get([FromUri] decimal latitude,[FromUri] decimal longitude)
        {
            var clientIp = HttpContext.Current.Request.UserHostAddress;

            var ipLocationForecast = RequestHelper.GetForecastByIP(clientIp, _forecastService);
            ipLocationForecast.Description = "Prognoza za lokaciju na osnovu IP adrese";

            var forecastOnLocationSentByUser = _forecastService.GetForecast(latitude, longitude);
            forecastOnLocationSentByUser.Description = $"Prognoza za lokaciju: latidute: {latitude}, longitude: {longitude}";

            return Json(new List<Forecast> { ipLocationForecast, forecastOnLocationSentByUser });
        }        
    }
}