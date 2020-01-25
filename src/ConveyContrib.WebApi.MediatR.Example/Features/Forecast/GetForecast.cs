using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace ConveyContrib.WebApi.MediatR.Example.Features.Forecast
{
    public class GetForecast : IRequest<IEnumerable<WeatherForecast>>
    {
    }
    
    public class GetForecastHandler : RequestHandler<GetForecast, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        protected override IEnumerable<WeatherForecast> Handle(GetForecast request)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}