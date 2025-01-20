using System.Text;
using Application.Exceptions;
using Common.Interfaces;


namespace Web.API.Middlewares;

public class LoggingMiddleware(RequestDelegate next, ILogService<LoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogService<LoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var method = context.Request.Method; 
        var path = context.Request.Path; 

        var body = await ReadRequestBody(context.Request);

        _logger.LogInfo("Start endpoint {method} {path} - Data: {body}",method, $"{path}", body);

        try
        {
            await _next(context);
        }

        catch (ValidationException ex)
        {
            _logger.LogInfo("Validation Failed - Data: {data}", new{ex.Message, ex.Result});
        }

        catch (UserNotFoundError ex)
        {
            _logger.LogInfo("User not found - Data: {data}", new{ex.Id});
        }

        catch (ApiMappedErrors ex)
        {
            _logger.LogInfo("Mapped error - Data: {data}", new{ex.Message});
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error - Data: {data}", new{ex.Message});
        }

        finally{ _logger.LogInfo("Finished endpoint {method} {path}", method, $"{path}"); }

    }


    private static async Task<string> ReadRequestBody(HttpRequest request) {
        request.EnableBuffering();

        using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();

        request.Body.Seek(0, SeekOrigin.Begin);
        return body;
    }

}
