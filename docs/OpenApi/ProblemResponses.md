# Problem Responses

Every configured error response is declared once in `components.responses` and
referenced from operations that already document the status code.

```csharp
builder.Services.AddCoreOpenApi(options =>
{
    options.ProblemResponses.SchemaId = "AppProblemDetails";
    options.ProblemResponses.TypePrefix = "urn:orders:error:";
    options.ProblemResponses.   TraceIdExample =
        "00-aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa-bbbbbbbbbbbbbbbb-01";

    // Rate limiting applies to every endpoint -> document 429 everywhere.
    options.ProblemResponses.Definitions
        .Single(d => d.StatusCode == "429")
        .IncludeWhenMissing = true;
});
```

`SchemaId` names the component that every problem response references. Its default
is `ProblemDetails`, so the document only resolves when your API has a schema with that
exact name. If your error type is `CoreProblemDetails` (the type shipped by this
library), set `SchemaId = "CoreProblemDetails"`; otherwise the generated document
contains a dangling `$ref`.

`IncludeWhenMissing` defaults to `false`, so a status code is only added to
operations that already declare it. An existing `400` is replaced only when it
already looks like a problem response.