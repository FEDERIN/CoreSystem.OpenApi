# OpenAPI

`CoreSystem.OpenApi.Swashbuckle` provides the OpenAPI/Swagger infrastructure shared
by CoreSystem-based APIs on .NET 8, .NET 9 and .NET 10.

- One-call wiring: `AddCoreOpenApi` / `UseCoreOpenApi`
- Bearer security scheme applied to every operation
- Response attributes (from the base `CoreSystem.OpenApi` package): `ProducesOkAttribute<T>`, `ProducesCreatedAttribute<T>`, `ProducesNoContentAttribute`
- Shared problem-details responses declared once as `$ref` components
- Patched document cached in memory

See [Getting Started](GettingStarted.md), [Configuration](Configuration.md) and
[Problem Responses](ProblemResponses.md).