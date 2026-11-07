using Core.OpenApi.Errors;

namespace Core.OpenApi.UnitTests;

public class CoreValidationProblemDetailsTests
{
    [Fact]
    public void DefaultConstructor()
    {
        var pd = new CoreValidationProblemDetails { ErrorCode = "E", TraceId = "T" };
        Assert.Equal("E", pd.ErrorCode);
    }

    [Fact]
    public void ErrorsConstructor()
    {
        var errors = new Dictionary<string, string[]> { ["field"] = ["msg"] };
        var pd = new CoreValidationProblemDetails(errors);
        Assert.True(pd.Errors.ContainsKey("field"));
    }
}