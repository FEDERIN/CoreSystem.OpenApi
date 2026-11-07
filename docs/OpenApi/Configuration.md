# Configuration

Configure via `CoreOpenApiOptions` (extends `OpenApiOptions`):

- `Title`, `Description`, `Version`, `DocumentName`
- `Servers` (`IList<OpenApiServerDescriptor>`)
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