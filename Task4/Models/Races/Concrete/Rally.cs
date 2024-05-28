using Task4.Models.Cars.Concrete;
using Task4.Models.Races.Abstract;

namespace Task4.Models.Races.Concrete;

public class Rally : Race
{
    public override void StartRace(Bolid[] cars)
    {
        foreach (var bolidCar in cars)
        {
            const float complexityСoefficient = 0.1f;
            var bolidIsFinished = new Random().NextDouble() > (bolidCar.FailureRate + complexityСoefficient);

            var bolidRaceEventArgs = new RaceEventArgs
            {
                CarName = bolidCar.CarName,
                DriverName = bolidCar.DriverName,
                CarNumber = bolidCar.CarNumber,
                RaceTime = TimeSpan.FromSeconds(100 * (1 - bolidCar.WinRate) + new Random().Next(12000, 6030))
            };

            if (bolidIsFinished)
            {
                OnRaceFinished(bolidRaceEventArgs);
            }
            else
            {
                OnRaceFailed(bolidRaceEventArgs);
            }
        }
    }
}
