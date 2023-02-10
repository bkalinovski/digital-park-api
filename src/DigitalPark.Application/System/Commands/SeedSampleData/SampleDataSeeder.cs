using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using DigitalPark.Application.Common.Interfaces;
using DigitalPark.Domain.Entities;
using DigitalPark.Domain.Enums;

namespace DigitalPark.Application.System.Commands.SeedSampleData;

public class SampleDataSeeder
{
    private readonly IDigitalParkDbContext _context;

    public SampleDataSeeder(IDigitalParkDbContext context)
    {
        _context = context;
    }
    
    public async Task SeedAllAsync(CancellationToken cancellationToken)
    {
        if (_context.Locations.Any())
        {
            return;
        }

        await SeedLocationsAsync(cancellationToken);

        await SeedEventsAsync(cancellationToken);
    }
    
    private async Task SeedLocationsAsync(CancellationToken cancellationToken)
    {
        var locations = new[]
        {
            new Location { Id = Guid.Parse("05661C1F-6413-4DBB-BD8B-7CAEFAA8051B"), TitleRo = "Technology Hall", TitleEng = "Technology Hall", IsActive = true, CreatedAt = DateTime.Now },
            new Location { Id = Guid.Parse("D564B15D-2623-4708-9A70-71FDD60AB7E6"), TitleRo = "Innovation Hall", TitleEng = "Innovation Hall", IsActive = true, CreatedAt = DateTime.Now },
            new Location { Id = Guid.Parse("2AFDADC5-00F5-4ADD-989D-5DB59099C093"), TitleRo = "Community Hall", TitleEng = "Community Hall", IsActive = true, CreatedAt = DateTime.Now },
            new Location { Id = Guid.Parse("F9754BD0-FE78-4E3A-922C-DF57E7E5BF01"), TitleRo = "Lobby", TitleEng = "Lobby", IsActive = true, CreatedAt = DateTime.Now },
            new Location { Id = Guid.Parse("3B23D4BB-BB3F-437D-ADB3-428779BFC317"), TitleRo = "Outdoor Space", TitleEng = "Outdoor Space", IsActive = true, CreatedAt = DateTime.Now },
            new Location { Id = Guid.Parse("50DA7309-272F-4E25-B457-3FC2BA3F8686"), TitleRo = "Digital Garden", TitleEng = "Digital Garden", IsActive = true, CreatedAt = DateTime.Now }
        };

        _context.Locations.AddRange(locations);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedEventsAsync(CancellationToken cancellationToken)
    {
        var locations = await _context.Locations.ToListAsync(cancellationToken);
        var communityHall = locations.First(t => t.Id == Guid.Parse("2AFDADC5-00F5-4ADD-989D-5DB59099C093"));
        
        var events = new[]
        {
            new Event
            {
                Id = Guid.Parse("B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB"), 
                TitleRo = "dotnetdays", TitleEng = "dotnetdays", 
                DescriptionRo = "random description ro", DescriptionEng = "random description eng", 
                ImageRo = "http://cdnedge.starnet.md/digital-park-website/events/B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB/dotnetdays-banner.png", 
                ImageEng = "http://cdnedge.starnet.md/digital-park-website/events/B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB/dotnetdays-banner.png", 
                Location = communityHall, 
                Date = new DateTime(2022, 9, 22, 14, 0, 0 ),
                Contents = new List<EventContent>
                {
                    new EventContent()
                    {
                        EventId = Guid.Parse("B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB"),
                        OrderNr = 1,
                        Type = ContentType.Text,
                        Language = ContentLanguage.Eng,
                        Content = "Talks: dotnetdays conference team comes to Chisinau with a mini event @DigitalPark Some speakers: Irina Dominte(Scurtu) - Microsoft MVP, Software Architect Bogdan Bujdea - Microsoft MVP, CTO Mihăiță Cristian, Maxcode Dorina Ivascu - .NET developer Alexandr Ivanov - Talks: Going minimal in .NET, are we there yet? - Bogdan Bujdea Minimal APIs are one of the hottest features from .NET 6, and probably you've seen a lot of chatter about them on the internet. But have you seen them in your codebase? Or maybe you don't think they're ready for production yet? That's the question that we're going to answer in this talk. Let's put Minimal APIs to the test and see if they're ready for real-world applications. You'll see what features they lack, what comes next in .NET 7, and most importantly at the end of the talk you'll be able to decide if they are ready or not for production code. gRPC deep-dive - Irina Scurtu With an increasing need for scalability and performance dictated by the modern web, it becomes harder and harder to choose an API paradigm that is suitable for service to service communication. While the classical models still work and have their own merits, some of them rely heavily on documentation, extensive coordination between teams or code-sharing. We use shared libraries, and over time our projects become intertwined with dependencies. In these cases, we need something to untangle those and reduce coupling. Welcome gRPC. gRPC has been around for a while and .NET Core 3.0 welcomes it as a first-class citizen. It is contract-based, performant - with smaller response/request bodies, perfect for polyglot environments and supports different models – from client-server, to bi-directional streaming out of the box. DevOps Post-ITs - Mihăiță Cristian, Maxcode"
                    },
                    new EventContent()
                    {
                        EventId = Guid.Parse("B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB"),
                        OrderNr = 1,
                        Type = ContentType.Text,
                        Language = ContentLanguage.Ro,
                        Content = "Discuții: echipa conferinței dotnetdays vine la Chișinău cu un mini eveniment @DigitalPark Câțiva vorbitori: Irina Dominte(Scurtu) - Microsoft MVP, Software Architect Bogdan Bujdea - Microsoft MVP, CTO Mihăiță Cristian, Maxcode Dorina Ivascu - .NET developer Alexandr Ivanov - Talks: Devenind minim în .NET, suntem deja acolo? - Bogdan Bujdea Minimal API-urile sunt una dintre cele mai tari caracteristici de la .NET 6 și probabil că ați văzut multe discuții despre ele pe internet. Dar le-ai „văzut” în baza ta de cod? Sau poate nu crezi că sunt încă pregătiți pentru producție? Aceasta este întrebarea la care vom răspunde în această discuție. Să testăm API-urile minime și să vedem dacă sunt pregătite pentru aplicații din lumea reală. Veți vedea ce caracteristici le lipsesc, ce urmează în .NET 7 și, cel mai important, la sfârșitul discuției, veți putea decide dacă sunt gata sau nu pentru codul de producție. gRPC deep-dive - Irina Scurtu Cu o nevoie tot mai mare de scalabilitate și performanță dictată de web-ul modern, devine din ce în ce mai greu să alegeți o paradigmă API care să fie potrivită pentru comunicarea service-service. În timp ce modelele clasice încă funcționează și au propriile lor merite, unele dintre ele se bazează în mare măsură pe documentare, pe coordonarea extinsă între echipe sau pe partajarea codului. Folosim biblioteci partajate și, în timp, proiectele noastre se împletesc cu dependențe. În aceste cazuri, avem nevoie de ceva pentru a le descurca și a reduce cuplarea. Bun venit gRPC. gRPC există de ceva vreme, iar .NET Core 3.0 îl salută ca un cetățean de primă clasă. Este bazat pe contract, performant - cu corpuri de răspuns/cereri mai mici, perfect pentru medii poliglote și suportă diferite modele – de la client-server, până la streaming bidirecțional. DevOps Post-ITs - Mihăiță Cristian, Maxcode"
                    },
                    new EventContent()
                    {
                        EventId = Guid.Parse("B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB"),
                        OrderNr = 2,
                        Type = ContentType.Gallery,
                        Language = ContentLanguage.Both,
                        Content = JsonSerializer.Serialize(new []
                        {
                            "http://cdnedge.starnet.md/digital-park-website/events/B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB/dotnetdays-image-1.png",
                            "http://cdnedge.starnet.md/digital-park-website/events/B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB/dotnetdays-image-2.png",
                            "http://cdnedge.starnet.md/digital-park-website/events/B8CD823E-46C5-4F6B-BD50-A1D6CF6423CB/dotnetdays-image-3.png"
                        })
                    }
                }
            }
        };

        _context.Events.AddRange(events);

        await _context.SaveChangesAsync(cancellationToken);
    }
}