using Entities.Entities;
using Infrastructure.Repositories.WeatherForecasts;

namespace Application.WeatherForecasts.Queries;

public class GetWeatherForecastQuery : BaseQuery<List<WeatherForecast>>
{
}

public class GetWeatherForecastQueryHandler : BaseQueryHandler<GetWeatherForecastQuery, List<WeatherForecast>>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public GetWeatherForecastQueryHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    protected override async Task<List<WeatherForecast>> HandleQuery(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        return await _weatherForecastRepository.WeatherForecasts();
    }
}
