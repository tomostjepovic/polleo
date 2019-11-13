using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WeatherApi.Models;

namespace WeatherApi.Helpers
{
    public class RequestHelper
    {
        public static Forecast GetForecastByIP(string ipAddress, IForecastService forecastService)
        {
            var client = new RestClient("http://ip-api.com");

            var request = new RestRequest($"/json/{ipAddress}", Method.GET);

            var response = client.Execute<IpApiResponse>(request);
                       
            return forecastService.GetForecast(response.Data.Lat, response.Data.Lon);
        }

        public class IpApiResponse
        {
            public decimal Lat { get; set; }
            public decimal Lon { get; set; }
        }
    }
}