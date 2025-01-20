using System.Text.Json;
using Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Common.Services;

public class LogService<T>(ILogger<T> logger): ILogService<T>
{
    private readonly ILogger<T> _logger = logger;

    /// <summary>
    ///     Log info parsing the args with serialization
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogInfo(string message,params object?[] args ){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogInformation(message, args);
    }


    /// <summary>
    ///     Log info parsing the args with serialization including exception
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogInfo(Exception? ex, string message,params object?[] args){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogInformation(ex, message, args);
    }


    /// <summary>
    ///     Log error parsing the args with serialization
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogError(string message,params object?[] args ){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogError(message, args);
    }


    /// <summary>
    ///     Log error parsing the args with serialization including exception
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogError(Exception? ex, string message,params object?[] args){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogError(ex, message, args);
    }


    /// <summary>
    ///     Log warn parsing the args with serialization
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogWarn(string message,params object?[] args ){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogWarning(message, args);
    }

    /// <summary>
    ///     Log warn parsing the args with serialization including exception
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogWarn(Exception? ex, string message,params object?[] args){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogWarning(ex, message, args);
    }

    /// <summary>
    ///     Log critical parsing the args with serialization
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogCritical(string message,params object?[] args ){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogCritical(message, args);
    }


    /// <summary>
    ///     Log critical parsing the args with serialization including exception
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogCritical(Exception? ex, string message,params object?[] args){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogCritical(ex, message, args);
    }


    /// <summary>
    ///     Log trace parsing the args with serialization
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogTrace(string message,params object?[] args ){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogTrace(message, args);
    }


    /// <summary>
    ///     Log trace parsing the args with serialization including exception
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogTrace(Exception? ex, string message,params object?[] args){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogTrace(ex, message, args);
    }


    /// <summary>
    ///     Log debug parsing the args with serialization
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogDebug(string message,params object?[] args ){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogDebug(message, args);
    }


    /// <summary>
    ///     Log debug parsing the args with serialization including exception
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogDebug(Exception? ex, string message,params object?[] args){
        for (int i = 0; i < args.Length; i++) { args[i] = ObjToString(args[i]!); }
        _logger.LogDebug(ex, message, args);
    }


    /// <summary>
    ///     Parse any object using deserialization and serialization
    ///     to print any object with the correct JSON format 
    /// </summary>
    /// <param name="data"></param>
    /// /// <returns></returns> 
    private static string ObjToString(object data){
        string stringData;
        try
        {
            var deserialization = JsonSerializer.Deserialize<object>(data.ToString()!);
            stringData = JsonSerializer.Serialize(deserialization);
        }
        catch (JsonException)
        {
            if (data is not string)
                stringData = JsonSerializer.Serialize(data);
            else 
                stringData = $"{data}";
        }
        return stringData;
    } 

}