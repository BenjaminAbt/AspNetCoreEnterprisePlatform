using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace BenjaminAbt.MyDemoPlatform.Configuration;

public class MissingConfigurationException : Exception
{
    public MissingConfigurationException() { }

    public MissingConfigurationException(string message) : base(message) { }

    public MissingConfigurationException(string message, Exception innerException)
        : base(message, innerException) { }

    public static void ThrowIfNull(
        [NotNull] object? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument is null) throw new MissingConfigurationException($"Value of {paramName} is missing.");
    }
    public static void ThrowIfNullOrEmpty(
        [NotNull] string? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument is null) throw new MissingConfigurationException($"Value of {paramName} is missing.");
    }
}
