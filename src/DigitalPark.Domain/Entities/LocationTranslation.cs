namespace DigitalPark.Domain.Entities;

public class LocationTranslation
{
    public Guid LocationId { get; set; }

    public string LanguageCode { get; set; }

    public string Title { get; set; }

    public virtual Location Location { get; set; }

    public virtual Language Language { get; set; }
}