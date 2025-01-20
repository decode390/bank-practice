using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<BankContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("Bank"));
        });
    }
}