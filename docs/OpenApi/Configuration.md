# Configuration

Configure via `CoreOpenApiOptions` (extends `OpenApiOptions`):

- `Title`, `Description`, `Version`, `DocumentName`
- `Servers` (`IList<OpenApiServerDescriptor>`)

> **Docker / port mapping:** In Development the library appends the addresses from
> `ASPNETCORE_URLS`/`DOTNET_URLS` as "Local" servers, but only when the host is a
> concrete (non-wildcard) address. When the app binds to a wildcard address such as
> `http://+:8080` (common in containers), or when the host port differs from the
> container port (for example `-p 80:8080`), the binding cannot be turned into a
> callable URL automatically. In those cases add the server manually, for example:
>
> ```csharp
> options.Servers.Add(new OpenApiServerDescriptor
> {
>     Url = "http://localhost:80",
>     Description = "Local"
> });
> ```
- `Bearer` security scheme
- `IncludeXmlComments`, `XmlCommentFiles`, `IncludeControllerXmlComments`
- `SwaggerRoutePrefix` (default `swagger`)
- `JsonEndpointRoute`, `OriginalJsonRouteTemplate`
- `EnableDocumentPatch`, `CachePatchedDocument`
- `ConfigureSwaggerGen`, `ConfigureJsonEndpoint` callbacks

Example:

```csharp
builder.Services.AddCoreOpenApi(options =>
{
    options.Title = "Orders API";
    options.ConfigureSwaggerGen = gen => gen.EnableAnnotations();
    options.ConfigureJsonEndpoint = endpoint => endpoint
        .DisableRateLimiting()
        .ExcludeFromDescription();
});
```