using DigitalPark.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalPark.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DigitalParkDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DigitalParkDatabase")));

        services.AddScoped<IDigitalParkDbContext>(provider => provider.GetService<DigitalParkDbContext>());

        return services;
    }
}