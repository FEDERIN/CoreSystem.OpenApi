using Core.OpenApi.Options;
using Core.OpenApi.Swashbuckle.DependencyInjection;
using Core.OpenApi.Swashbuckle.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var configured = builder.Configuration.GetSection("OpenApi").Get<OpenApiOptions>() ?? new OpenApiOptions();
builder.Services.AddCoreOpenApi(options =>
{
    options.CopyFrom(configured);
    options.ConfigureSwaggerGen = gen => gen.EnableAnnotations();

    options.ProblemResponses.TypePrefix = "urn:sample:error:";
    options.ProblemResponses.TraceIdExample =
        "00-aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa-bbbbbbbbbbbbbbbb-01";
    options.ProblemResponses.Definitions
        .Single(d => d.StatusCode == "429")
        .IncludeWhenMissing = true;

    options.Servers.Add(new OpenApiServerDescriptor
    {
        Url = "https://staging.example.com",
        Description = "Staging"
    });
    options.Servers.Add(new OpenApiServerDescriptor
    {
        Url = "https://demo.example.com",
        Description = "Demo"
    });
    options.Servers.Add(new OpenApiServerDescriptor
    {
        Url = "https://api.example.com",
        Description = "Production"
    });
});

var app = builder.Build();

app.UseCoreOpenApi();
app.MapControllers();

app.Run();