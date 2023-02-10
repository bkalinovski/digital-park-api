namespace DigitalPark.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }

    public string TitleRo { get; set; }

    public string TitleEng { get; set; }

    public string DescriptionRo { get; set; }

    public string DescriptionEng { get; set; }
    
    public string ImageRo { get; set; }

    public string ImageEng { get; set; }

    public DateTime Date { get; set; }

    public Guid LocationId { get; set; }

    public virtual ICollection<EventContent> Contents { get; set; } = new HashSet<EventContent>();

    public virtual Location Location { get; set; }
}