using DigitalPark.Domain.Enums;

namespace DigitalPark.Domain.Entities;

public class EventContent
{
    public int Id { get; set; }

    public Guid EventId { get; set; }

    public int OrderNr { get; set; }

    public ContentType Type { get; set; }

    public ContentLanguage Language { get; set; }

    //Can be plain text or JSON (ex: ["url_img1", "url_img2", "url_img3",])
    public string Content { get; set; }

    public virtual Event Event { get; set; }
}