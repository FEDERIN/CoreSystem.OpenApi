# CoreSystem.OpenApi

> **OpenAPI/Swagger integration packages for .NET, extracted from the CoreSystem monorepo.**

CoreSystem.OpenApi provides reusable OpenAPI/Swagger helpers and filters for ASP.NET Core
applications, published as independent NuGet packages.

## Projects

- `CoreSystem.OpenApi` — core abstractions and shared OpenAPI helpers.
- `CoreSystem.OpenApi.Swashbuckle` — Swashbuckle integration (filters, annotations).

## Build & Test

```bash
dotnet build CoreSystem.OpenApi.slnx -c Release
dotnet test --solution CoreSystem.OpenApi.slnx -c Release
dotnet format CoreSystem.OpenApi.slnx --verify-no-changes
```

## Documentation

See the `docs/` folder and `mkdocs.yml` for the documentation site.

## License

Released under the MIT License.
