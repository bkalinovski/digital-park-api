namespace DigitalPark.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public Guid LocationId { get; set; }

    public virtual ICollection<EventContent> Contents { get; set; } = new HashSet<EventContent>();

    public virtual Location Location { get; set; }

    public virtual ICollection<EventTranslation> Translations { get; set; } = new HashSet<EventTranslation>();
}