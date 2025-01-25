using System.Reflection;
using Infrastructure;
using Application;
using Microsoft.OpenApi.Models;
using Web.API.Middlewares;
using Common.Services;
using Common.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc(
        "v1", 
        new OpenApiInfo{
            Version = "1",
            Title = "Bank API",
            Description = "Bank API generated by Miguel Fandiño",
        }
    );

    var basePath = AppContext.BaseDirectory;
    options.IncludeXmlComments(Path.Combine(basePath, "Web.API.xml"));
    options.IncludeXmlComments(Path.Combine(basePath, "Application.xml"));
});
builder.Services.AddCors(options => {
    options.AddPolicy(
        "AllowAll",
        builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
    );
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddTransient(typeof(ILogService<>), typeof(LogService<>));

builder.Services.AddControllers();

// Layers services
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ParseResponseMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
