using Microsoft.Extensions.Logging;

namespace Common.Interfaces;

public interface ILogService<T>{

    void LogInfo(string message,params object?[] args );
    void LogInfo(Exception? ex, string message,params object?[] args);
    void LogError(string message,params object?[] args );
    void LogError(Exception? ex, string message,params object?[] args);
    void LogWarn(string message,params object?[] args );
    void LogWarn(Exception? ex, string message,params object?[] args);
    void LogCritical(string message,params object?[] args );
    void LogCritical(Exception? ex, string message,params object?[] args);
    void LogTrace(string message,params object?[] args );
    void LogTrace(Exception? ex, string message,params object?[] args);
    void LogDebug(string message,params object?[] args );
    void LogDebug(Exception? ex, string message,params object?[] args);
}