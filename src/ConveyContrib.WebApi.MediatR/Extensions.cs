using System;
using Convey;
using Convey.WebApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ConveyContrib.WebApi.MediatR
{
    public static class Extensions
    {
        public static IConveyBuilder AddCommandHandlers(this IConveyBuilder builder)
        {
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return builder;
        }
        
        public static IApplicationBuilder UseMediatREndpoints(this IApplicationBuilder app,
            Action<IDispatcherEndpointsBuilder> builder, bool useAuthorization = true)
        {
            var definitions = app.ApplicationServices.GetService<WebApiEndpointDefinitions>();
            app.UseRouting();
            if (useAuthorization) app.UseAuthorization();

            app.UseEndpoints(router => builder(new MediatrEndpointsBuilder(
                new EndpointsBuilder(router, definitions))));

            return app;
        }

        public static IApplicationBuilder UseMediatRPublicContracts<T>(this IApplicationBuilder app,
            string endpoint = "/_contracts")
        {
            return app.UsePublicContracts(endpoint, typeof(T));
        }

        public static IApplicationBuilder UseMediatRPublicContracts(this IApplicationBuilder app,
            bool attributeRequired, string endpoint = "/_contracts")
        {
            return app.UsePublicContracts(endpoint, null, attributeRequired);
        }

        private static IApplicationBuilder UsePublicContracts(this IApplicationBuilder app,
            string endpoint = "/_contracts", Type? attributeType = null, bool attributeRequired = true)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                endpoint = "/_contracts";
            }

            endpoint = endpoint.TrimStart('/');
            
            var targetAttributeType = attributeType ?? typeof(PublicContractAttribute);
            
            return app.UseMiddleware<PublicContractsMiddleware>($"/{endpoint}", targetAttributeType, attributeRequired);
        }
    }
}