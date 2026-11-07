using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new OpenApiInfo { Title = "Baseline API", Version = "v1" });
    gen.EnableAnnotations();

    var xmlFile = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".xml");
    if (File.Exists(xmlFile)) gen.IncludeXmlComments(xmlFile);

    gen.AddServer(new OpenApiServer
    {
        Url = "https://staging.example.com",
        Description = "Staging"
    });
    gen.AddServer(new OpenApiServer
    {
        Url = "https://demo.example.com",
        Description = "Demo"
    });
    gen.AddServer(new OpenApiServer
    {
        Url = "https://api.example.com",
        Description = "Production"
    });
    gen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header. Example: Bearer {token}"
    });

    gen.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(ui => ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Baseline API v1"));

app.MapControllers();
app.Run();