using Core.OpenApi.Swashbuckle.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Core.OpenApi.Swashbuckle.IntegrationTests;

public class OpenApiOptionsValidationTests
{
    [Fact]
    public void AddCoreOpenApi_EmptyDocumentName_Throws() =>
        Assert.Throws<ArgumentException>(() =>
            new ServiceCollection().AddCoreOpenApi(o => o.DocumentName = " "));

    [Fact]
    public void AddCoreOpenApi_EmptySwaggerRoutePrefix_Throws() =>
        Assert.Throws<ArgumentException>(() =>
            new ServiceCollection().AddCoreOpenApi(o => o.SwaggerRoutePrefix = " "));

    [Fact]
    public void AddCoreOpenApi_EmptyVersion_Throws() =>
        Assert.Throws<ArgumentException>(() =>
            new ServiceCollection().AddCoreOpenApi(o => o.Version = " "));

    [Fact]
    public void AddCoreOpenApi_ProblemResponseMissingStatusCode_Throws() =>
        Assert.Throws<ArgumentException>(() =>
            new ServiceCollection().AddCoreOpenApi(o =>
                o.ProblemResponses.Definitions.Add(new Core.OpenApi.Options.ProblemResponseDefinition
                {
                    StatusCode = " ",
                    ComponentName = "cmp",
                    ErrorCode = "ERR"
                })));

    [Fact]
    public void AddCoreOpenApi_ProblemResponseMissingComponentName_Throws() =>
        Assert.Throws<ArgumentException>(() =>
            new ServiceCollection().AddCoreOpenApi(o =>
                o.ProblemResponses.Definitions.Add(new Core.OpenApi.Options.ProblemResponseDefinition
                {
                    StatusCode = "400",
                    ComponentName = " ",
                    ErrorCode = "ERR"
                })));

    [Fact]
    public void AddCoreOpenApi_ProblemResponseMissingErrorCode_Throws() =>
        Assert.Throws<ArgumentException>(() =>
            new ServiceCollection().AddCoreOpenApi(o =>
                o.ProblemResponses.Definitions.Add(new Core.OpenApi.Options.ProblemResponseDefinition
                {
                    StatusCode = "400",
                    ComponentName = "cmp",
                    ErrorCode = " "
                })));
}