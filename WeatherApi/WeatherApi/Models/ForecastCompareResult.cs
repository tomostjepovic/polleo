using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApi.Models
{
    public class ForecastCompareResult
    {
        public Forecast ForecastOnLocationByIPAddress { get; set; }
        public Forecast ForecastOnLocationSentByUser { get; set; }
    }
}