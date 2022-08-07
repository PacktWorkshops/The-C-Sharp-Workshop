using System;
using CsvHelper.Configuration;

namespace Chapter09.Service.Dtos;

public class WeatherForecast
{
    public DateTime Datetime { get; set; }
    public string Temperature { get; set; }
    public string Conditions { get; set; }
}