namespace Core.OpenApi.Options;

/// <summary>
/// Common OpenAPI options shared by all providers.
/// </summary>
public class OpenApiOptions
{
    /// <summary>Document name.</summary>
    public string DocumentName { get; set; } = "v1";
    /// <summary>Title.</summary>
    public string? Title { get; set; }
    /// <summary>Description.</summary>
    public string? Description { get; set; }
    /// <summary>Version.</summary>
    public string Version { get; set; } = "v1";
    /// <summary>Bearer.</summary>
    public BearerSecurityOptions Bearer { get; } = new();
    /// <summary>Servers.</summary>
    public IList<OpenApiServerDescriptor> Servers { get; } = [];

    /// <summary>
    /// Copies values from another instance, allowing configuration from appsettings.
    /// </summary>
    public OpenApiOptions CopyFrom(OpenApiOptions source)
    {
        ArgumentNullException.ThrowIfNull(source);
        DocumentName = source.DocumentName;
        Title = source.Title;
        Description = source.Description;
        Version = source.Version;
        Bearer.Enabled = source.Bearer.Enabled;
        Bearer.SchemeName = source.Bearer.SchemeName;
        Bearer.HeaderName = source.Bearer.HeaderName;
        Bearer.Scheme = source.Bearer.Scheme;
        Bearer.BearerFormat = source.Bearer.BearerFormat;
        Bearer.Description = source.Bearer.Description;
        Servers.Clear();
        foreach (var s in source.Servers) Servers.Add(s);
        return this;
    }
}