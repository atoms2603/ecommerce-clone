namespace Entities.Entities;

public class WeatherForecast : BaseEntity
{
    public WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        TemperatureF = 32 + (int)(TemperatureC / 0.5556);
    }
    public int TemperatureF { get; set; }
}
