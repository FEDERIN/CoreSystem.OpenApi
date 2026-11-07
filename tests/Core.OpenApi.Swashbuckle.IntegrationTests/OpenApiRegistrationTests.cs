using Core.OpenApi.Swashbuckle.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Core.OpenApi.Swashbuckle.IntegrationTests;

public class OpenApiRegistrationTests
{
    [Fact]
    public void AddCoreOpenApi_NullServices_ThrowsArgumentNullException()
    {
        IServiceCollection? services = null;
        Assert.Throws<ArgumentNullException>(() => services!.AddCoreOpenApi());
    }

    [Fact]
    public void AddCoreOpenApi_ReturnsSameCollection()
    {
        var services = new ServiceCollection();
        var result = services.AddCoreOpenApi();
        Assert.Same(services, result);
    }

    [Fact]
    public void AddCoreOpenApi_DevelopmentUrlsAndBearerAndServers()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        Environment.SetEnvironmentVariable("ASPNETCORE_URLS", "http://localhost:5000;http://localhost:5001");

        try
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddRouting();
            var env = new FakeWebHostEnvironment();
            services.AddSingleton<IWebHostEnvironment>(env);
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostEnvironment>(env);
            services.AddCoreOpenApi(o =>
            {
                o.Title = "My API";
                o.Bearer.Enabled = true;
                o.Servers.Add(new Core.OpenApi.Options.OpenApiServerDescriptor { Url = "https://example.com", Description = "prod" });
            });

            var provider = services.BuildServiceProvider();
            var swagger = provider.GetRequiredService<ISwaggerProvider>();
            Assert.NotNull(swagger);
        }
        finally
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
            Environment.SetEnvironmentVariable("ASPNETCORE_URLS", null);
        }
    }

    [Fact]
    public void AddCoreOpenApi_ConfigureCallbackAndXmlComments()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        var env2 = new FakeWebHostEnvironment { EnvironmentName = "Production" };
        services.AddSingleton<IWebHostEnvironment>(env2);
        services.AddSingleton<Microsoft.Extensions.Hosting.IHostEnvironment>(env2);
        services.AddCoreOpenApi(o =>
        {
            o.IncludeXmlComments = true;
            o.ConfigureSwaggerGen = g => g.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "x", Version = "v2" });
        });

        var provider = services.BuildServiceProvider();
        var swagger = provider.GetRequiredService<ISwaggerProvider>();
        Assert.NotNull(swagger);
    }

}