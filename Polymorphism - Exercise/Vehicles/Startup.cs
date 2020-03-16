namespace Vehicles
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var infForCar = Console.ReadLine()
                .Split(' ')
                .ToArray();
            var infForTruck = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var car = new Car(double.Parse(infForCar[1]),double.Parse(infForCar[2]));
            var truck = new Truck(double.Parse(infForTruck[1]),double.Parse(infForTruck[2]));

            var num = int.Parse(Console.ReadLine());
            var command = new string[] { };

            for (int i = 0; i < num; i++)
            {
                command = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                if (command[1] == "Car")
                {
                    var vehicle = GetInVehicle(car, command[0], double.Parse(command[2]));
                    car = vehicle as Car;
                }
                else if (command[1] == "Truck")
                {
                    var vehicle = GetInVehicle(truck, command[0], double.Parse(command[2]));
                    truck = vehicle as Truck;
                }
            }

            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
        }

        public static Vehicles GetInVehicle(Vehicles vehicle, string command, double value)
        {
            if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(value));
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(value);
            }

            return vehicle;
        }
    }
}
