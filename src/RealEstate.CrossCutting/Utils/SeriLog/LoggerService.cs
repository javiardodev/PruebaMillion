using Microsoft.Extensions.Logging;

namespace RealEstate.CrossCutting.Utils.SeriLog;

public class LoggerService<T> : ILoggerService<T>
{
    private readonly ILogger<T> _logger;

    public LoggerService(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message) => _logger.LogInformation(message);

    public void LogError(string message, Exception ex) => _logger.LogError(ex, message);

    public void LogWarning(string message) => _logger.LogWarning(message);
}
