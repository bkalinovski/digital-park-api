namespace DigitalPark.Domain.Entities;

public class EventTranslation
{
    public Guid EventId { get; set; }

    public string LanguageCode { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Image { get; set; }
    
    public virtual Event Event { get; set; }

    public virtual Language Language { get; set; }
}