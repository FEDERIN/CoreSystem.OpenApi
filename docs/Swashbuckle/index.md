# ⚡ CoreSystem.OpenApi.Swashbuckle

`CoreSystem.OpenApi.Swashbuckle` provides the OpenAPI/Swagger infrastructure shared
by CoreSystem-based APIs on .NET 8, .NET 9 and .NET 10.

![NuGet](https://img.shields.io/nuget/v/CoreSystem.OpenApi.Swashbuckle?style=for-the-badge)
![Downloads](https://img.shields.io/nuget/dt/CoreSystem.OpenApi.Swashbuckle?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%209.0%20%7C%2010.0-blue?style=for-the-badge)

- One-call wiring: `AddCoreOpenApi` / `UseCoreOpenApi`
- Bearer security scheme applied to every operation
- Response attributes (from the base `CoreSystem.OpenApi` package): `ProducesOkAttribute<T>`, `ProducesCreatedAttribute<T>`, `ProducesNoContentAttribute`
- Shared problem-details responses declared once as `$ref` components
- Patched document cached in memory