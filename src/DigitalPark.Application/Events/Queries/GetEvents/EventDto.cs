using DigitalPark.Application.Common.Mappings;
using DigitalPark.Domain.Entities;

namespace DigitalPark.Application.Events.Queries.GetEvents;

public class EventDto : IMapFrom<Event>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public DateTime Date { get; set; }

    public string Location { get; set; }
}