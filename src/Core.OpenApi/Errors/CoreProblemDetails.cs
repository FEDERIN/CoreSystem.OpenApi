using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Errors;

/// <summary>
/// Base problem details carrying the CoreSystem <c>errorCode</c> and <c>traceId</c>
/// fields, shared by every problem response in the document.
/// </summary>
public class CoreProblemDetails : ProblemDetails
{
    /// <summary>Gets or sets the application error code.</summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>Gets or sets the trace identifier.</summary>
    [JsonPropertyName("traceId")]
    public string? TraceId { get; set; }
}