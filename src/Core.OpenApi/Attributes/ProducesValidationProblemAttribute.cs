using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Attributes;

/// <summary>
/// Documents an HTTP 400 response whose body is a <see cref="Core.OpenApi.Errors.CoreValidationProblemDetails"/>.
/// </summary>
public sealed class ProducesValidationProblemAttribute : ProducesResponseTypeAttribute
{
    /// <summary>Initializes a new instance.</summary>
    public ProducesValidationProblemAttribute()
        : base(typeof(Errors.CoreValidationProblemDetails), StatusCodes.Status400BadRequest)
    {
    }
}