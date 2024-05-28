namespace Task4.Models.Races.Abstract;

public class RaceEventArgs
{
    public string? CarName { get; init; }
    
    public string? DriverName { get; init; }

    public string? CarNumber { get; init; }
    
    public TimeSpan RaceTime { get; set; }
}