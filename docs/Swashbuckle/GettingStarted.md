# 🚀 Getting Started

Welcome to **CoreSystem.OpenApi.Swashbuckle**, the Swashbuckle integration for
CoreSystem-based APIs.

## Prerequisites

Before getting started, ensure you have:

- .NET 8 SDK, .NET 9 SDK or .NET 10 SDK
- An IDE such as Visual Studio 2022 or JetBrains Rider
- Basic knowledge of C# and Dependency Injection

## Installation

Install the package:

```bash
dotnet add package CoreSystem.OpenApi.Swashbuckle
```

## Register the services

Register the document and map the endpoint during application startup:

```csharp
using Core.OpenApi.Swashbuckle.DependencyInjection;
using Core.OpenApi.Swashbuckle.Extensions;
using Core.OpenApi.Options;

builder.Services.AddCoreOpenApi(options =>
{
    options.Title = "Orders API";
    options.Description = "Order management endpoints";
    options.Servers.Add(new OpenApiServerDescriptor
    {
        Url = "https://api.example.com",
        Description = "Production"
    });
});

var app = builder.Build();
app.UseCoreOpenApi();
```

## First Example

Annotate controllers with the response attributes:

```csharp
using Core.OpenApi.Attributes;

[HttpPost]
[ProducesCreated<Item>]
public ActionResult<Item> Create([FromBody] Item item) => ...
```

The application now serves `/swagger/v1/swagger.json`, `/swagger` (Swagger UI) and
`swagger-original/v1/swagger.json` (unpatched output).

## Next Steps

Choose a topic to continue learning.

- [Configuration](Configuration.md)
- [Problem Responses](ProblemResponses.md)
