using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ConverterController : ControllerBase
{
    [HttpGet]
    public int ToCelsius(
        [Required] [FromQuery] ETemperatureUnit from,
        [Required] [FromQuery] ETemperatureUnit to,
        [Required] [FromQuery] double value)
    {
        return (from, to) switch
        {
            (ETemperatureUnit.Celsius, ETemperatureUnit.Fahrenheit) => Converter.ToFahrenheit(ETemperatureUnit.Celsius,
                value),
            (ETemperatureUnit.Kelvin, ETemperatureUnit.Fahrenheit) => Converter.ToFahrenheit(ETemperatureUnit.Kelvin,
                value),
            (ETemperatureUnit.Fahrenheit, ETemperatureUnit.Celsius) => Converter.ToCelsius(ETemperatureUnit.Celsius,
                value),
            (ETemperatureUnit.Kelvin, ETemperatureUnit.Celsius) => Converter.ToCelsius(ETemperatureUnit.Celsius, value),
            (ETemperatureUnit.Fahrenheit, ETemperatureUnit.Kelvin) => Converter.ToKelvin(ETemperatureUnit.Celsius,
                value),
            (ETemperatureUnit.Celsius, ETemperatureUnit.Kelvin) => Converter.ToKelvin(ETemperatureUnit.Celsius, value),
            _ => (int) value
        };
    }
}