using Task4.Models.Cars;
using Task4.Models.Cars.Abstract;
using Task4.Models.Cars.Concrete;
using Task4.Models.Races.Abstract;
using Task4.Models.Races.Concrete;

var bolidCars = new Bolid[]
{
    new Bolid
    {
        Team = "Red Bull Racing Honda RBPT",
        CarNumber = "1",
        CarName = "RB19",
        DriverName = "Max Verstappen",
        WinRate = 0.1498f, // 161 / 1075
        FailureRate = 0.05f
    },
    new Bolid
    {
        Team = "Ferrari",
        CarNumber = "16",
        CarName = "SF23",
        DriverName = "Charles Leclerc",
        WinRate = 0.1051f, 
        FailureRate = 0.06f
    },
    new Bolid
    {
        Team = "Red Bull Racing Honda RBPT",
        CarNumber = "11",
        CarName = "RB19",
        DriverName = "Sergio Perez",
        WinRate = 0.0995f,
        FailureRate = 0.06f
    },
    new Bolid
    {
        Team = "McLaren Mercedes",
        CarNumber = "4",
        CarName = "MCL60",
        DriverName = "Lando Norris",
        WinRate = 0.0940f,
        FailureRate = 0.07f
    },
    new Bolid
    {
        Team = "Ferrari",
        CarNumber = "55",
        CarName = "SF23",
        DriverName = "Carlos Sainz",
        WinRate = 0.0865f,
        FailureRate = 0.08f
    },
    new Bolid
    {
        Team = "McLaren Mercedes",
        CarNumber = "81",
        CarName = "MCL60",
        DriverName = "Oscar Piastri",
        WinRate = 0.0493f,
        FailureRate = 0.09f
    },
    new Bolid
    {
        Team = "Mercedes",
        CarNumber = "63",
        CarName = "W14",
        DriverName = "George Russell",
        WinRate = 0.0409f,
        FailureRate = 0.05f
    },
    new Bolid
    {
        Team = "Mercedes",
        CarNumber = "44",
        CarName = "W14",
        DriverName = "Lewis Hamilton",
        WinRate = 0.0326f,
        FailureRate = 0.04f
    },
    new Bolid
    {
        Team = "Aston Martin Aramco Mercedes",
        CarNumber = "14",
        CarName = "AMR23",
        DriverName = "Fernando Alonso",
        WinRate = 0.0307f,
        FailureRate = 0.08f
    },
    new Bolid
    {
        Team = "RB Honda RBPT",
        CarNumber = "22",
        CarName = "RB19",
        DriverName = "Yuki Tsunoda",
        WinRate = 0.0140f,
        FailureRate = 0.12f
    },
    new Bolid
    {
        Team = "Aston Martin Aramco Mercedes",
        CarNumber = "18",
        CarName = "AMR23",
        DriverName = "Lance Stroll",
        WinRate = 0.0102f,
        FailureRate = 0.1f
    },
    new Bolid
    {
        Team = "Haas Ferrari",
        CarNumber = "27",
        CarName = "VF-23",
        DriverName = "Nico Hulkenberg",
        WinRate = 0.0056f,
        FailureRate = 0.15f
    },
    new Bolid
    {
        Team = "RB Honda RBPT",
        CarNumber = "3",
        CarName = "RB19",
        DriverName = "Daniel Ricciardo",
        WinRate = 0.0047f,
        FailureRate = 0.10f
    },
    new Bolid
    {
        Team = "Alpine Renault",
        CarNumber = "31",
        CarName = "A523",
        DriverName = "Esteban Ocon",
        WinRate = 0.0009f,
        FailureRate = 0.10f
    },
    new Bolid
    {
        Team = "Haas Ferrari",
        CarNumber = "20",
        CarName = "VF-23",
        DriverName = "Kevin Magnussen",
        WinRate = 0.0009f,
        FailureRate = 0.15f
    },
    new Bolid
    {
        Team = "Williams Mercedes",
        CarNumber = "23",
        CarName = "FW45",
        DriverName = "Alexander Albon",
        WinRate = 0.0007f,
        FailureRate = 0.2f
    },
    new Bolid
    {
        Team = "Kick Sauber Ferrari",
        CarNumber = "24",
        CarName = "C43",
        DriverName = "Zhou Guanyu",
        WinRate = 0.0003f,
        FailureRate = 0.2f
    },
    new Bolid
    {
        Team = "Alpine Renault",
        CarNumber = "10",
        CarName = "A523",
        DriverName = "Pierre Gasly",
        WinRate = 0.0006f,
        FailureRate = 0.15f
    },
    new Bolid
    {
        Team = "Kick Sauber Ferrari",
        CarNumber = "77",
        CarName = "C43",
        DriverName = "Valtteri Bottas",
        WinRate = 0.0009f,
        FailureRate = 0.13f
    },
    new Bolid
    {
        Team = "Williams Mercedes",
        CarNumber = "2",
        CarName = "FW45",
        DriverName = "Logan Sargeant",
        WinRate = 0f,
        FailureRate = 0.2f
    }
};

var bolidResultTable = new List<RaceEventArgs>();
var bolidFinished = new List<RaceEventArgs>();
var bolidFailed = new List<RaceEventArgs>();

Console.WriteLine("List of drivers:");
Console.WriteLine("NO     DRIVER              CAR       TEAM");
foreach (var e in bolidCars)
{
    Console.WriteLine($"{e.CarNumber, -7}{e.DriverName, -20}{e.CarName, -10}{e.Team}");
}

var cityRace = new City { NameRace = "City Race" };
cityRace.RaceFinished += OnRaceFinished;
cityRace.RaceFailed += OnRaceFailed;

Console.WriteLine("\nStarting City Race...");
cityRace.StartRace(bolidCars);

bolidResultTable.AddRange(bolidFinished.OrderBy(r => r.RaceTime).ToList());
bolidResultTable.AddRange(bolidFailed);

int position = 1; // не подобається можливо ти знаєш як можна зберігши функціонал позбутися зміної?

Console.WriteLine($"\nList of results \"{cityRace.NameRace}\":");
Console.WriteLine("POS    NO     DRIVER              CAR       TIME");
foreach (var e in bolidResultTable)
{
    Console.WriteLine($"{position, -7}{e.CarNumber, -7}{e.DriverName, -20}{e.CarName, -10}{e.RaceTime:hh\\:mm\\:ss}");
    position++;
}


var rallyRace = new City { NameRace = "Rally Race" };
rallyRace.RaceFinished += OnRaceFinished;
rallyRace.RaceFailed += OnRaceFailed;

bolidFailed.Clear();
bolidFinished.Clear();

Console.WriteLine("\nStarting Rally Race...");
rallyRace.StartRace(bolidCars);

bolidResultTable.Clear();
bolidResultTable.AddRange(bolidFinished.OrderBy(r => r.RaceTime).ToList());
bolidResultTable.AddRange(bolidFailed);

position = 1;

Console.WriteLine($"\nList of results \"{rallyRace.NameRace}\":");
Console.WriteLine("POS    NO     DRIVER              CAR       TIME");
foreach (var e in bolidResultTable)
{
    Console.WriteLine($"{position, -7}{e.CarNumber, -7}{e.DriverName, -20}{e.CarName, -10}{e.RaceTime:hh\\:mm\\:ss}");
    position++;
}

Console.ReadKey();

void OnRaceFinished(object? sender, RaceEventArgs e)
{
    bolidFinished.Add(e);
}

void OnRaceFailed(object? sender, RaceEventArgs e)
{
    bolidFailed.Add(e);
    e.RaceTime = TimeSpan.Zero;
}