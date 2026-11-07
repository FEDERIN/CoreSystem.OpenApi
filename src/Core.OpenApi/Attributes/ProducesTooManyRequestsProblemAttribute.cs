using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Attributes;

/// <summary>
/// Documents an HTTP 429 response whose body is a <see cref="Core.OpenApi.Errors.CoreProblemDetails"/>.
/// </summary>
public sealed class ProducesTooManyRequestsProblemAttribute : ProducesResponseTypeAttribute
{
    /// <summary>Initializes a new instance.</summary>
    public ProducesTooManyRequestsProblemAttribute()
        : base(typeof(Errors.CoreProblemDetails), StatusCodes.Status429TooManyRequests)
    {
    }
}