using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Core.OpenApi.Swashbuckle.IntegrationTests;

public class FakeWebHostEnvironment : IWebHostEnvironment
{
    public string ApplicationName { get; set; } = "Test";
    public IFileProvider WebRootFileProvider { get; set; } = null!;
    public string WebRootPath { get; set; } = string.Empty;
    public string EnvironmentName { get; set; } = "Development";
    public string ContentRootPath { get; set; } = string.Empty;
    public IFileProvider ContentRootFileProvider { get; set; } = null!;
}