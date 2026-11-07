using Core.OpenApi.Swashbuckle.DependencyInjection;
using Core.OpenApi.Swashbuckle.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace Core.OpenApi.Swashbuckle.IntegrationTests;

public class UseCoreOpenApiTests
{
    [Fact]
    public void UseCoreOpenApi_ReturnsSameApp()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddCoreOpenApi();
        var app = builder.Build();
        var result = app.UseCoreOpenApi();
        Assert.Same(app, result);
    }

    [Fact]
    public void GetDocument_CachedAndUncached()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        var env = new FakeWebHostEnvironment();
        services.AddSingleton<IWebHostEnvironment>(env);
        services.AddSingleton<Microsoft.Extensions.Hosting.IHostEnvironment>(env);
        services.AddCoreOpenApi(o => { o.CachePatchedDocument = false; o.EnableDocumentPatch = false; });
        var provider = services.BuildServiceProvider();
        var swagger = provider.GetRequiredService<ISwaggerProvider>();
        var cache = provider.GetRequiredService<IMemoryCache>();
        var options = provider.GetRequiredService<IOptions<Core.OpenApi.Swashbuckle.Options.CoreOpenApiOptions>>().Value;

        var type = typeof(OpenApiApplicationBuilderExtensions);
        var method = type.GetMethod("GetDocument", BindingFlags.NonPublic | BindingFlags.Static)!;
        var doc = (string)method.Invoke(null, new object[] { swagger, cache, options })!;
        Assert.False(string.IsNullOrWhiteSpace(doc));
    }

    [Fact]
    public void GetDocument_Cached()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        var env = new FakeWebHostEnvironment();
        services.AddSingleton<IWebHostEnvironment>(env);
        services.AddSingleton<Microsoft.Extensions.Hosting.IHostEnvironment>(env);
        services.AddCoreOpenApi();
        var provider = services.BuildServiceProvider();
        var swagger = provider.GetRequiredService<ISwaggerProvider>();
        var cache = provider.GetRequiredService<IMemoryCache>();
        var options = provider.GetRequiredService<IOptions<Core.OpenApi.Swashbuckle.Options.CoreOpenApiOptions>>().Value;

        var type = typeof(OpenApiApplicationBuilderExtensions);
        var method = type.GetMethod("GetDocument", BindingFlags.NonPublic | BindingFlags.Static)!;
        var doc1 = (string)method.Invoke(null, new object[] { swagger, cache, options })!;
        var doc2 = (string)method.Invoke(null, new object[] { swagger, cache, options })!;
        Assert.Equal(doc1, doc2);
    }

    [Fact]
    public void UseCoreOpenApi_WithConfigureJsonEndpoint()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddCoreOpenApi(o => o.ConfigureJsonEndpoint = e => { });
        var app = builder.Build();
        var result = app.UseCoreOpenApi();
        Assert.Same(app, result);
    }
}