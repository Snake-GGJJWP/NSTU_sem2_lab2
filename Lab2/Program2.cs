using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Transactions;
using Lab2.Class;

public static class Program2
{
    static void Main(string[] args)
    {
        ShowcasePolymorphism();
    }

    public static void ShowcasePolymorphism()
    {
        Console.WriteLine("=== POLYMORPHISM SHOWCASE ===\n");

        List<Vehicle> vehicles = new List<Vehicle>
        {
        new Car("Toyota", Drive.FWD, new Engine(12345, "1ZZ-FE", 1.6, 95, EngineType.Gasoline), 180),
        new Car("BMW", Drive.RWD, new Engine(67890, "N52", 2.5, 255, EngineType.Gasoline), 250, 120),
        new Train(101, 5000000, new Engine(6780, "ALCO-282", 5.0, 600, EngineType.Diesel), 120, 80),
        new Express(12, true, 202, 3000000, new Engine(6790, "ALCO-282", 5.0, 600, EngineType.Diesel), 160, 140)
        };

        // Add carriages to trains
        Train regularTrain = (Train)vehicles[2];
        regularTrain.AddCar(new PassengerCarriage(15000, 80, CarriageClass.Econom, true));
        regularTrain.AddCar(new CargoCarriage(20000, 25000, "Coal"));

        Express expressTrain = (Express)vehicles[3];
        expressTrain.AddCar(new PassengerCarriage(12000, 60, CarriageClass.VIP, true));
        expressTrain.AddCar(new PassengerCarriage(13000, 72, CarriageClass.Regular, true));

        // ToString() calls
        Console.WriteLine("Vehicles list output:");
        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle.ToString());
            Console.WriteLine();
        }

        // Create a list of different carriages
        List<Carriage> carriages = new List<Carriage>
        {
        new PassengerCarriage(15000, 80, CarriageClass.Econom, true),
        new PassengerCarriage(18000, 50, CarriageClass.VIP, true),
        new CargoCarriage(20000, 25000, "Coal"),
        new CargoCarriage(22000, 30000, "Oil")
        };

        // Demonstrate polymorphic ToString() and TotalWeight() calls
        Console.WriteLine("CARRIAGES (polymorphic behavior):");
        foreach (Carriage carriage in carriages)
        {
            Console.WriteLine(carriage.ToString());
            Console.WriteLine($"Total Weight: {carriage.TotalWeight()} kg");
            Console.WriteLine();
        }

        Console.WriteLine("\nEngine object inherited methods\n");

        // Demonstrate Engine methods inherited from Object
        Engine engine1 = new Engine(11111, "V8", 1.6, 300, EngineType.Gasoline);
        Engine engine2 = new Engine(11111, "V8", 1.6, 300, EngineType.Gasoline);
        Engine engine3 = new Engine(22222, "ElectricMotor", 2.5, 400, EngineType.Electric);

        Console.WriteLine($"engine1.ToString(): {engine1.ToString()}");
        Console.WriteLine($"engine2.ToString(): {engine2.ToString()}");
        Console.WriteLine($"engine3.ToString(): {engine3.ToString()}");
        Console.WriteLine();

        Console.WriteLine("Equals:");
        Console.WriteLine($"engine1.Equals(engine2): {engine1.Equals(engine2)}"); // True (same serial & model)
        Console.WriteLine($"engine1.Equals(engine3): {engine1.Equals(engine3)}"); // False
        Console.WriteLine($"engine1 == engine2: {engine1 == engine2}"); // False (reference comparison)
        Console.WriteLine();

        Console.WriteLine("Hash:");
        Console.WriteLine($"engine1.GetHashCode(): {engine1.GetHashCode()}");
        Console.WriteLine($"engine2.GetHashCode(): {engine2.GetHashCode()}");
        Console.WriteLine($"engine3.GetHashCode(): {engine3.GetHashCode()}");
        Console.WriteLine();

        // Demonstrate Move() method calls
        Console.WriteLine("Vehicles move:");
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Move(); // Each vehicle type has its own implementation
        }
    }
}

