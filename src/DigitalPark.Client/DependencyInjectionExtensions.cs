using DigitalPark.Application.Common.Interfaces;
using DigitalPark.Client.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalPark.Client;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddScoped<ILanguageProvider, LanguageProvider>();

        return services;
    }
}