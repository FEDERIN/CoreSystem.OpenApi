using Core.OpenApi.Swashbuckle.Options;

namespace Core.OpenApi.Swashbuckle.UnitTests;

public class CoreOpenApiOptionsTests
{
    [Fact]
    public void Validate_Throws_WhenDocumentNameEmpty()
    {
        var o = new CoreOpenApiOptions { DocumentName = "" };
        Assert.Throws<ArgumentException>(() => o.Validate());
    }

    [Fact]
    public void ResolvedRoutes()
    {
        var o = new CoreOpenApiOptions();
        Assert.Contains("swagger.json", o.ResolvedJsonEndpointRoute);
        Assert.Contains("-original", o.ResolvedOriginalJsonRouteTemplate);
    }
}