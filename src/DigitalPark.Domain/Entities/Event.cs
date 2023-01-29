using System;

namespace DigitalPark.Domain.Entities;

public class EventSpace
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime Date { get; set; }

    public Guid SpaceId { get; set; }

    public string Image { get; set; }

    public virtual EventSpace Space { get; set; }
}