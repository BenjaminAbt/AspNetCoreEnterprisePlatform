namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;

public abstract class SqlServerDbContextConfig
{
    /// <summary>
    /// Instance Name, cannot be null
    /// </summary>
    public string? ServerHostname { get; set; }
    /// <summary>
    /// Database Name, cannot be null
    /// </summary>
    public string? DatabaseName { get; set; }

    /// <summary>
    /// Connection string template, cannot be null
    /// </summary>
    public string? ConnectionStringTemplate { get; set; }

    ///// <summary>
    ///// Additional options
    ///// </summary>
    //public string? Appendix { get; set; }

    public bool LoggingEnabled { get; set; } = false;
}
