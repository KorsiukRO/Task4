
using Task4.Models.Cars.Concrete;
using Task4.Models.Races.Abstract;

namespace Task4.Models.Races.Concrete;

public class City : Race
{
    public override void StartRace(Bolid[] cars)
    {
        foreach (var bolidCar in cars)
        {
            var bolidIsFinished = new Random().NextDouble() > bolidCar.FailureRate;

            var bolidRaceEventArgs = new RaceEventArgs
            {
                CarName = bolidCar.CarName,
                DriverName = bolidCar.DriverName,
                CarNumber = bolidCar.CarNumber,
                RaceTime = TimeSpan.FromSeconds(100 * (1 - bolidCar.WinRate) + new Random().Next(6000, 6015))
            };

            if (bolidIsFinished)
            {
                OnRaceFinished(bolidRaceEventArgs);
                Console.WriteLine($"{bolidRaceEventArgs.DriverName} finished with a time of {bolidRaceEventArgs.RaceTime:hh\\:mm\\:ss}");
                Thread.Sleep(300);
            }
            else
            {
                OnRaceFailed(bolidRaceEventArgs);
                Console.WriteLine($"{bolidRaceEventArgs.DriverName} retired from the race");
                Thread.Sleep(300);
            }
        }
    }
}