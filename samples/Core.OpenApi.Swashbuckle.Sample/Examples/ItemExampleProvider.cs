using Core.OpenApi.Swashbuckle.Sample.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Core.OpenApi.Swashbuckle.Sample.Examples;

public sealed class ItemExampleProvider : IExamplesProvider<Item>
{
    public Item GetExamples() => new() { Id = 1, Name = "Sample item" };
}