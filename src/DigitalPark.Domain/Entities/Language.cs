namespace DigitalPark.Domain.Entities;

public class Language
{
    public string Code { get; set; }

    public string Title { get; set; }

    public virtual ICollection<LocationTranslation> LocationTranslations { get; set; } = new HashSet<LocationTranslation>();
    
    public virtual ICollection<EventTranslation> EventTranslations { get; set; } = new HashSet<EventTranslation>();
    
    public virtual ICollection<EventContentTransation> EventContentTransations { get; set; } = new HashSet<EventContentTransation>();
}