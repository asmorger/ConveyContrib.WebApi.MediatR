# ConveyContrib.WebApi.MediatR
MediatR integration for [Convey](https://convey-stack.github.io/).  Sample project [here](https://github.com/asmorger/ConveyContrib.WebApi.MediatR/tree/master/src/ConveyContrib.WebApi.MediatR.Example)

## Overview
Convey is a coordinated set of helper methods developed by [DevMentors](https://devmentors.io/).  They provide a really innovative way of creating standards-based integrations for common tools and methodologies.

## Why this project?
Convey provides a robust CQRS implementation out-of-the-box, but [MediatR](https://github.com/jbogard/MediatR) is the defacto standard CQRS impelmentation in .Net.  MediatR also provides a methodology for cross-cutting concerns via Pipelines, which is something that the standard Convey implementation does not yet implement.  These two concerns, the industry familiarity with MediatR and Pipelines support, is why I created this integration.

# Getting Started

## Installation
`dotnet add package ConveyContrib.WebApi.MediatR`

## Usage

Extend your `Program.cs` startup to include Convey's `AddWebApi()` to add their required services.  Also use `.AddCommandHandlers()` to add the `MediatR` infrastructure.

```
WebHost.CreateDefaultBuilder(args)
  .ConfigureServices(services =>
      services
          .AddConvey()
          .AddWebApi()
          .AddCommandHandlers()
          .Build()
```

To define custom endopints, the process is the same as `Convey's`, except for the method name used.  Subsitute `UseEndpoints()` with `UseMediatREndpoints()`.  

```
app
    .UseMediatREndpoints(endpoints => endpoints
        .Get("", ctx => ctx.Response.WriteAsync("Hello"))
        .Get<GetForecast, IEnumerable<WeatherForecast>>("WeatherForecast")
    );
```

# FAQ

## How does it work?
I would encourage you to go through the [Convey WebAPI Getting Started Guide](https://convey-stack.github.io/documentation/Web-API/) to see how their current implementation works.  I did my best to stick as closely to their implementation as I could for the sake of consistency.

## Design considerations
Because I'm integrating with someone else's library, I have tried to ensure there won't be any usage/naming conflicts with their implementations.  As such, I've used their builder system, but extended my own methods off of it.
