# 🧩 Problem Responses

Every configured error response is declared once in `components.responses` and
referenced from operations that already document the status code.

```csharp
builder.Services.AddCoreOpenApi(options =>
{
    options.ProblemResponses.SchemaId = "CoreProblemDetails";
    options.ProblemResponses.ValidationSchemaId = "CoreValidationProblemDetails";
    options.ProblemResponses.TypePrefix = "urn:orders:error:";
    options.ProblemResponses.TraceIdExample =
        "00-aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa-bbbbbbbbbbbbbbbb-01";

    // Rate limiting applies to every endpoint -> document 429 everywhere.
    options.ProblemResponses.Definitions
        .Single(d => d.StatusCode == "429")
        .IncludeWhenMissing = true;
});
```

`SchemaId` names the component that every problem response references. Its default
is `CoreProblemDetails`, the problem type shipped by this library. The example above
sets the default explicitly for clarity.

> **Note:** `SchemaId` can name any schema present in the document, either one from this
> library or the error class of an external provider. The problem response attributes
> (`ProducesNotFoundProblemAttribute`, `ProducesTooManyRequestsProblemAttribute`, and the
> others) keep documenting `CoreProblemDetails` on their own, so changing `SchemaId` does not
> affect them. The only failure is a `SchemaId` whose name does not exist in
> `components.schemas`, which leaves a dangling `$ref`.

To use your own error type, set `SchemaType` (and `ValidationSchemaType` for the `400`) to
the class that defines it. The library registers that schema in the document, so the
responses resolve. The class name must equal `SchemaId`, or the configuration fails:

```csharp
builder.Services.AddCoreOpenApi(options =>
{
    options.ProblemResponses.SchemaId = nameof(AppProblemDetails);
    options.ProblemResponses.SchemaType = typeof(AppProblemDetails);
});
```

The shared schemas `CoreProblemDetails` and `CoreValidationProblemDetails` are always
registered in `components.schemas`, even when no operation uses them directly. This prevents the `Could not resolve reference` error for
responses such as `429` that are added to every operation.

`ValidationSchemaId` names the schema of the validation (`400`) response, `ValidationError`.
When it is not set, the `400` response uses `CoreValidationProblemDetails` (the body documented by
`ProducesValidationProblemAttribute`) while `SchemaId` keeps its default. If you change
`SchemaId`, the `400` response follows it. Set `ValidationSchemaId` explicitly when your API
returns a different validation type, and make sure that schema exists in the document.

`IncludeWhenMissing` defaults to `false`, so a status code is only added to
operations that already declare it. An existing `400` is replaced only when it
already looks like a problem response.