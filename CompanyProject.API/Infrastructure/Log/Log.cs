namespace CompanyProject.API.Infrastructure.Log;

internal static class Log
{
    internal static ILoggerFactory LoggerFactory { get; set; }

    internal static ILogger CreateLogger<T>()
    {
        return LoggerFactory.CreateLogger<T>();
    }

    internal static ILogger CreateLogger(string categoryName)
    {
        return LoggerFactory.CreateLogger(categoryName);
    }
}