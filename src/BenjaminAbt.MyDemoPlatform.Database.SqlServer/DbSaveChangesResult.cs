namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;

public readonly struct DbSaveChangesResult
{
    public int ResultCount { get; }

    public DbSaveChangesResult(int resultCount)
        => ResultCount = resultCount;

    public static implicit operator int(DbSaveChangesResult result)
        => result.ResultCount;

    public static implicit operator DbSaveChangesResult(int resultCount)
        => new(resultCount);
}
