# Getting Started

Install the package:

```bash
dotnet add package CoreSystem.OpenApi.Swashbuckle
```

Register the document and map the endpoint:

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

The application now serves `/swagger/v1/swagger.json`, `/swagger` (Swagger UI) and
`swagger-original/v1/swagger.json` (unpatched output).

Annotate controllers with the response attributes:

```csharp
using Core.OpenApi.Attributes;

[HttpPost]
[ProducesCreated<Item>]
public ActionResult<Item> Create([FromBody] Item item) => ...
```