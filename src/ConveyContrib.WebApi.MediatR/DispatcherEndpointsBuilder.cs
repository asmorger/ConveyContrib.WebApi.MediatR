using System;
using System.Threading;
using System.Threading.Tasks;
using Convey.WebApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConveyContrib.WebApi.MediatR
{
    public interface IDispatcherEndpointsBuilder
    {
        IDispatcherEndpointsBuilder Get(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null,
            params string[] policies);

        IDispatcherEndpointsBuilder Get<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where T : class, IRequest<Unit>;

        IDispatcherEndpointsBuilder Get<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>;

        IDispatcherEndpointsBuilder Post(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null,
            params string[] policies);

        IDispatcherEndpointsBuilder Post<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where T : class, IRequest<Unit>;

        IDispatcherEndpointsBuilder Post<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>;


        IDispatcherEndpointsBuilder Put(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null,
            params string[] policies);

        IDispatcherEndpointsBuilder Put<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where T : class, IRequest<Unit>;

        IDispatcherEndpointsBuilder Put<TRequest, TResult>(string path,
            Func<TRequest, HttpContext, Task>? beforeDispatch = null,
            Func<TRequest, TResult, HttpContext, Task>? afterDispatch = null, 
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TRequest : class, IRequest<TResult>;

        IDispatcherEndpointsBuilder Delete(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null,
            params string[] policies);

        IDispatcherEndpointsBuilder Delete<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where T : class, IRequest<Unit>;

        IDispatcherEndpointsBuilder Delete<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>;
    }

    public class DispatcherEndpointsBuilder : IDispatcherEndpointsBuilder
    {
        private readonly IEndpointsBuilder _builder;

        public DispatcherEndpointsBuilder(IEndpointsBuilder endpointsBuilder)
        {
            _builder = endpointsBuilder;
        }


        public IDispatcherEndpointsBuilder Get(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null, params string[] policies)
        {
            _builder.Get(path, context, endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Get<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null, params string[] policies)
            where T : class, IRequest<Unit>
        {
            _builder.Get<T>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch), endpoint,
                auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Get<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>
        {
            _builder.Post<TQuery>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch),
                endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Post(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null, params string[] policies)
        {
            _builder.Post(path, context, endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Post<T>(string path,
            Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false,
            string? roles = null,
            params string[] policies)
            where T : class, IRequest<Unit>
        {
            _builder.Post<T>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch), endpoint,
                auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Post<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false,
            string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>
        {
            _builder.Post<TQuery>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch),
                endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Put(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null, params string[] policies)
        {
            _builder.Put(path, context, endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Put<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null, params string[] policies)
            where T : class, IRequest<Unit>
        {
            _builder.Put<T>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch), endpoint,
                auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Put<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>
        {
            _builder.Put<TQuery>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch),
                endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Delete(string path, Func<HttpContext, Task>? context = null,
            Action<IEndpointConventionBuilder>? endpoint = null, bool auth = false,
            string? roles = null, params string[] policies)
        {
            _builder.Delete(path, context, endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Delete<T>(string path, Func<T, HttpContext, Task>? beforeDispatch = null,
            Func<T, Unit, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null, params string[] policies)
            where T : class, IRequest<Unit>
        {
            _builder.Delete<T>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch),
                endpoint, auth, roles, policies);
            return this;
        }

        public IDispatcherEndpointsBuilder Delete<TQuery, TResult>(string path,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null,
            Action<IEndpointConventionBuilder>? endpoint = null,
            bool auth = false, string? roles = null,
            params string[] policies)
            where TQuery : class, IRequest<TResult>
        {
            _builder.Delete<TQuery>(path, (cmd, ctx) => BuildCommandContext(cmd, ctx, beforeDispatch, afterDispatch),
                endpoint, auth, roles, policies);
            return this;
        }

        private static async Task BuildCommandContext<TQuery, TResult>(
            TQuery command,
            HttpContext context,
            Func<TQuery, HttpContext, Task>? beforeDispatch = null,
            Func<TQuery, TResult, HttpContext, Task>? afterDispatch = null)
            where TQuery : class, IRequest<TResult>
        {
            if (beforeDispatch != null)
                await beforeDispatch(command, context);

            var handler = context.RequestServices.GetRequiredService<IRequestHandler<TQuery, TResult>>();
            var result = await handler.Handle(command, CancellationToken.None);

            if (afterDispatch is null)
            {
                context.Response.StatusCode = 200;
                return;
            }

            await afterDispatch(command, result, context);
        }
    }
}