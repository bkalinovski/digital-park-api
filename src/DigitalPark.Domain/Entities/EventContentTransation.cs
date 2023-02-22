namespace DigitalPark.Domain.Entities;

public class EventContentTransation
{
    public int EventContentId { get; set; }

    public string LanguageCode { get; set; }

    //Can be plain text or JSON (ex: ["url_img1", "url_img2", "url_img3",])
    public string Content { get; set; }
    
    public virtual EventContent EventContent { get; set; }

    public virtual Language Language { get; set; } 
}