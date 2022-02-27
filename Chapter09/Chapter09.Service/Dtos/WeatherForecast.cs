using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter09.Service.Dtos
{
    public class WeatherForecast
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
    }

}
