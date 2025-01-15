namespace RealEstate.CrossCutting.Utils.SeriLog;

public interface ILoggerService<T>
{
    void LogInformation(string message);
    void LogError(string message, Exception ex);
    void LogWarning(string message);
}