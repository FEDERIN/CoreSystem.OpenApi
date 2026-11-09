using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Attributes;

/// <summary>
/// Documents an HTTP 409 response whose body is a <see cref="Core.OpenApi.Errors.CoreProblemDetails"/>.
/// </summary>
public sealed class ProducesConflictProblemAttribute : ProducesResponseTypeAttribute
{
    /// <summary>Initializes a new instance.</summary>
    public ProducesConflictProblemAttribute()
        : base(typeof(Errors.CoreProblemDetails), StatusCodes.Status409Conflict)
    {
    }
}