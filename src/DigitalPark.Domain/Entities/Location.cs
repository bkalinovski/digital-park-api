namespace DigitalPark.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }

    public string TitleRo { get; set; }

    public string TitleEng { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
}