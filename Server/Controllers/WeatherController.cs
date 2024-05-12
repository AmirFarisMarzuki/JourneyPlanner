using Microsoft.AspNetCore.Mvc;
using JourneyPlanner.Shared.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System;

namespace PlanYourJourney.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Clear","Cold","Hazy","Rainy","Hot","Cloudy","Thunder"
        };

        //Logger instance injected to the controller via dependency injection. Allows controller to log messages.
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get(string lat, string lng, string date, string time)
        {
            var forecasts = new List<WeatherForecast>();

            DateTime? combinedDateTime = null;
            DateTime Date;
            DateTime Time;

            if (DateTime.TryParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Date))
            {
                // Parse the time string using the specified format
                if (DateTime.TryParseExact(time, "hhtt", CultureInfo.InvariantCulture, DateTimeStyles.None, out Time))
                {
                    // Combine date and time
                    combinedDateTime = Date.Add(Time.TimeOfDay);

                    // Output the combined DateTime
                    Console.WriteLine("Combined DateTime: " + combinedDateTime);
                }
            }

            var wSummary = GetRandomSummary();
            var forecast = new WeatherForecast
            {
                DateTime = combinedDateTime.ToString(),
                Summary = wSummary,
                Temperature = GetRandomNumber(wSummary)
            };

            // Add the generated forecast to the list
            forecasts.Add(forecast);


            return forecasts;
        }


        private string GetRandomSummary()
        {
            return Summaries[new Random().Next(Summaries.Length)];
        }

        private int GetRandomNumber(string summary)
        {
            if(summary == "Clear" || summary == "Hot"|| summary == "Hazy")
            {
                return new Random().Next(20,37);
            }
            else if(summary == "Cold" || summary == "Rainy" || summary == "Thunder" || summary == "Cloudy")
            {
                return new Random().Next(5, 20);
            }
            else
            {
                return new Random().Next(0, 37);
            }
        }
    }
}
