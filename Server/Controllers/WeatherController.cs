using Microsoft.AspNetCore.Mvc;
using JourneyPlanner.Shared.Models;

namespace PlanYourJourney.Controllers
{
    [ApiController]
    [Route("api/WeatherController")]
    public class WeatherController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Clear","Cold","Hazy","Rainy","Hot","Mild","Warm","Thunder"
        };

        //Logger instance injected to the controller via dependency injection. Allows controller to log messages.
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }


        [Route("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(string lat, string lng)  
        {
            var forecasts = new List<WeatherForecast>();

            for(int hour=8; hour<=17; hour++)
            {
                string timeString = new DateTime(1, 1, 1, hour, 0, 0).ToString("htt");
                var wSummary = GetRandomSummary();
                var forecast = new WeatherForecast
                {
                    Time = timeString,
                    Summary = wSummary,
                    Temperature = GetRandomNumber(wSummary)
                };

                // Add the generated forecast to the list
                forecasts.Add(forecast);
            }

            return forecasts;
        }


        private string GetRandomSummary()
        {
            return Summaries[new Random().Next(Summaries.Length)];
        }

        private int GetRandomNumber(string summary)
        {
            if(summary == "Warm" || summary == "Hot" || summary == "Mild" || summary == "Hazy")
            {
                return new Random().Next(20,37);
            }
            else if(summary == "Cold" || summary == "Rainy" || summary == "Thunder")
            {
                return new Random().Next(0, 20);
            }
            else
            {
                return new Random().Next(0, 37);
            }
        }
    }
}
