using System.Text;
using System.Text.Json;
using Common.Interfaces;

namespace Web.API.Middlewares;

public class ParseResponseMiddleware(RequestDelegate next, ILogService<ParseResponseMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogService<ParseResponseMiddleware> _logger = logger;
    public async Task InvokeAsync(HttpContext context) {
        
        _logger.LogInfo("To parse");


        var originalBodyStream = context.Response.Body;

        using var newBodyStream = new MemoryStream();

        context.Response.Body = newBodyStream;

        await _next(context);

        newBodyStream.Seek(0, SeekOrigin.Begin);
        var responseText = await new StreamReader(newBodyStream).ReadToEndAsync();
        newBodyStream.Seek(0, SeekOrigin.Begin);

        var newBody = new {
            Status = "prueba",
            Body = responseText
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(newBody), Encoding.UTF8);

        // try
        // {

        // }
        // catch (ApiMappedErrors ex)
        // {
        // }
        // catch (Exception ex)
        // {
        // }


    }
}
