using System.Collections.Generic;
using System.Threading.Tasks;
using Convey;
using Convey.WebApi;
using ConveyContrib.WebApi.MediatR.Example.Features.Forecast;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConveyContrib.WebApi.MediatR.Example
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                    services
                        .AddConvey()
                        .AddWebApi()
                        .AddCommandHandlers()
                        .Build()
                )
                .Configure(app =>
                {
                    app
                        .UseMediatRPublicContracts(false)
                        .UseMediatREndpoints(endpoints => endpoints
                            .Get("", ctx => ctx.Response.WriteAsync("Hello"))
                            .Get<GetForecast, IEnumerable<WeatherForecast>>("WeatherForecast")
                        );
                })
                .Build()
                .RunAsync();
        }
    }
}