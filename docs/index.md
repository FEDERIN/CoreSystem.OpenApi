# CoreSystem.OpenApi

Production-ready OpenAPI base contracts and models for .NET 8, .NET 9 and .NET 10.

CoreSystem.OpenApi contains the base contracts, options and models shared by every
OpenAPI provider implementation. It depends on ASP.NET Core but carries no
provider-specific code, so it can be referenced on its own for the response
attributes.

## Response attributes

- `ProducesOkAttribute<T>` — declares a `200 OK` with a typed body.
- `ProducesCreatedAttribute<T>` — declares a `201 Created` with a typed body.
- `ProducesNoContentAttribute` — declares a `204 No Content`.
- `ProducesNotFoundProblemAttribute` — declares a `404` problem response.
- `ProducesValidationProblemAttribute` — declares a `400` validation problem response.
- `ProducesTooManyRequestsProblemAttribute` — declares a `429` problem response.

## Installation

```bash
dotnet add package CoreSystem.OpenApi
```