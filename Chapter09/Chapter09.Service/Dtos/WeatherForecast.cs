using System;
using CsvHelper.Configuration;

namespace Chapter09.Service.Dtos;

public class WeatherForecast
{
    public string Address { get; set; }
    public DateTime Datetime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string ResolvedAddress { get; set; }
    public string Name { get; set; }
    public string WindDirection { get; set; }
    public string Temperature { get; set; }
    public string WindSpeed { get; set; }
    public string CloudCover { get; set; }
    public string HeatIndex { get; set; }
    public string ChancePrecipitation { get; set; }
    public double Precipitation { get; set; }
    public string SeaLevelPressure { get; set; }
    public string SnowDepth { get; set; }
    public string Snow { get; set; }
    public string RelativeHumidity { get; set; }
    public string WindGust { get; set; }
    public string WindChill { get; set; }
    public string Conditions { get; set; }
}