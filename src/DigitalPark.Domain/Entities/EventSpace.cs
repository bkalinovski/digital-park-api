using System;

namespace DigitalPark.Domain.Entities;

public class EventSpace
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Label { get; set; }

    public int Surface { get; set; }

    public int Capacity { get; set; }
}