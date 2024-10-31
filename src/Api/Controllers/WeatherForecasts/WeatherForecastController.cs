using Application.WeatherForecasts.Queries;
using Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherForecasts;

public class WeatherForecastController : AppBaseController
{
    public WeatherForecastController(IMediator mediatR) : base(mediatR)
    {
    }

    [HttpGet]
    public async Task<List<WeatherForecast>> WeatherForecasts() => await _mediatR.Send(new GetWeatherForecastQuery());
}
