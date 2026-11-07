using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Attributes;

/// <summary>
/// Documents an HTTP 404 response whose body is a <see cref="Core.OpenApi.Errors.CoreProblemDetails"/>.
/// </summary>
public sealed class ProducesNotFoundProblemAttribute : ProducesResponseTypeAttribute
{
    /// <summary>Initializes a new instance.</summary>
    public ProducesNotFoundProblemAttribute()
        : base(typeof(Errors.CoreProblemDetails), StatusCodes.Status404NotFound)
    {
    }
}