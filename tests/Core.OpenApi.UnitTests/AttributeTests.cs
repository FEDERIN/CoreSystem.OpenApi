using Core.OpenApi.Attributes;

namespace Core.OpenApi.UnitTests;

public class AttributeTests
{
    [Fact] public void ProducesOk() => Assert.NotNull(new ProducesOkAttribute<string>());
    [Fact] public void ProducesCreated() => Assert.NotNull(new ProducesCreatedAttribute<string>());
    [Fact] public void ProducesNoContent() => Assert.NotNull(new ProducesNoContentAttribute());
    [Fact] public void ProducesConflictProblem() => Assert.NotNull(new ProducesConflictProblemAttribute());
    [Fact] public void ProducesNotFoundProblem() => Assert.NotNull(new ProducesNotFoundProblemAttribute());
    [Fact] public void ProducesTooManyRequestsProblem() => Assert.NotNull(new ProducesTooManyRequestsProblemAttribute());
    [Fact] public void ProducesValidationProblem() => Assert.NotNull(new ProducesValidationProblemAttribute());
}