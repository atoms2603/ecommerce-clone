//using Entities.Entities;

//namespace Infrastructure.Repositories.WeatherForecasts;

//public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository
//{
//    public WeatherForecastRepository(AppDbContext context) : base(context)
//    {
//    }

//    public async Task<List<WeatherForecast>> WeatherForecasts()
//    {
//        await Task.Delay(100);
//        string[] summaries =
//        [
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        ];
//        var forecast = Enumerable.Range(1, 5).Select(index =>
//                new WeatherForecast
//                (
//                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                    Random.Shared.Next(-20, 55),
//                    summaries[Random.Shared.Next(summaries.Length)]
//                ))
//                .ToList();
//        return forecast;
//    }
//}
