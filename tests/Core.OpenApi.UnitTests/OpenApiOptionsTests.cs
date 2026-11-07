using Core.OpenApi.Options;

namespace Core.OpenApi.UnitTests;

public class OpenApiOptionsTests
{
    [Fact]
    public void Defaults()
    {
        var o = new OpenApiOptions();
        Assert.Equal("v1", o.DocumentName);
        Assert.Equal("v1", o.Version);
        Assert.Empty(o.Servers);
    }

    [Fact]
    public void CopyFrom_CopiesValues()
    {
        var src = new OpenApiOptions { Title = "T", Description = "D" };
        src.Servers.Add(new OpenApiServerDescriptor { Url = "http://x" });
        var dst = new OpenApiOptions().CopyFrom(src);
        Assert.Equal("T", dst.Title);
        Assert.Single(dst.Servers);
    }
}