using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Errors;

/// <summary>
/// Problem details for validation failures (HTTP 400), carrying the field-level
/// errors together with the CoreSystem <c>errorCode</c> and <c>traceId</c>.
/// </summary>
public class CoreValidationProblemDetails : ValidationProblemDetails
{
    /// <summary>Gets or sets the application error code.</summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>Gets or sets the trace identifier.</summary>
    [JsonPropertyName("traceId")]
    public string? TraceId { get; set; }

    /// <summary>Initializes a new instance.</summary>
    public CoreValidationProblemDetails()
    {
    }

    /// <summary>Initializes a new instance with the supplied errors.</summary>
    public CoreValidationProblemDetails(IDictionary<string, string[]> errors)
        : base(errors)
    {
    }
}