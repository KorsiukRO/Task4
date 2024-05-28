using Task4.Models.Cars.Concrete;

namespace Task4.Models.Races.Abstract;

public abstract class Race
{
   public required string NameRace { get; init; }

   public event EventHandler<RaceEventArgs>? RaceFinished; 
   public event EventHandler<RaceEventArgs>? RaceFailed;

   public abstract void StartRace(Bolid[] cars);
   
   protected void OnRaceFinished(RaceEventArgs e)
   {
      RaceFinished?.Invoke(this, e);
   }

   protected void OnRaceFailed(RaceEventArgs e)
   {
      RaceFailed?.Invoke(this, e);
   }
}