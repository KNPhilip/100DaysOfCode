namespace Carpool.Models;

public sealed class CarpoolEvent
{
    public string? Driver { get; set; }
    public Passenger[] Passengers { get; set; } = [];
    public string? Timestamp { get; set; }
}
