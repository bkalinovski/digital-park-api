using DigitalPark.Domain.Enums;

namespace DigitalPark.Domain.Entities;

public class EventContent
{
    public int Id { get; set; }

    public Guid EventId { get; set; }

    public int OrderNr { get; set; }

    public ContentType Type { get; set; }

    public virtual Event Event { get; set; }
    
    public virtual ICollection<EventContentTransation> Translations { get; set; } = new HashSet<EventContentTransation>();
}