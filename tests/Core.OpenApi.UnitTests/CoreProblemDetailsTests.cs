using Core.OpenApi.Errors;

namespace Core.OpenApi.UnitTests;

public class CoreProblemDetailsTests
{
    [Fact]
    public void CanSetProperties()
    {
        var pd = new CoreProblemDetails { ErrorCode = "E", TraceId = "T" };
        Assert.Equal("E", pd.ErrorCode);
        Assert.Equal("T", pd.TraceId);
    }
}