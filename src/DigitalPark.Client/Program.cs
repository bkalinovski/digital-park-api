using System.Text.Json;
using DigitalPark.Application;
using DigitalPark.Application.Common.Enums;
using DigitalPark.Application.Common.Interfaces;
using DigitalPark.Application.Events.Queries.GetEvents;
using DigitalPark.Application.System.Commands.SeedSampleData;
using DigitalPark.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalPark.Client;

public class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static async Task Main(string[] args)
    {
        var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

        var configurationBuilder = new ConfigurationBuilder()
                                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                       .AddEnvironmentVariables();

        if(isDevelopment)
        {
            configurationBuilder.AddUserSecrets<Program>();
        }

        Configuration = configurationBuilder.Build();

        var serviceProvider = new ServiceCollection()
                              .AddPersistenceServices(Configuration)
                              .AddApplicationServices()
                              .AddClientServices()
                              .BuildServiceProvider();

        var languageService = serviceProvider.GetService<ILanguageProvider>();
        languageService!.SetLanguage(ActiveLanguage.Ro);
        
        var mediator = serviceProvider.GetService<IMediator>();

        await mediator!.Send(new SeedSampleDataCommand());

        var eventsPaged = await mediator!.Send(new GetEventsQuery(1, 3));

        Console.WriteLine(JsonSerializer.Serialize(eventsPaged));
        
        Console.WriteLine("DONE.");
    }
}