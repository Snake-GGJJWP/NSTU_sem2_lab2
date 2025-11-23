using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Class
{
    internal class Train : Vehicle
    {
        private uint number; // train number
        private uint weightCapacity; // maximum carrying weight in kilograms

        private List<Carriage> cars = new List<Carriage>();
        private uint carriageTotalWeight;

        public uint Number { get; set; }
        public uint WeightCapacity { get; set; }

        public Train(uint number, uint capacity, Engine engine, uint maxSpeed, uint curSpeed = 0) : base(engine, maxSpeed, curSpeed)
        {
            Number = number;
            WeightCapacity = capacity;
        }

        public virtual void AddCar(Carriage car)
        {
            if (carriageTotalWeight + car.TotalWeight() > WeightCapacity) 
            {
                throw new OverflowException("Exceeded weight capacity");
            }
            cars.Add(car);
            carriageTotalWeight += car.TotalWeight();
        }

        public virtual void RemoveCar(int index) 
        {
            carriageTotalWeight -= cars[index].TotalWeight();
            cars.RemoveAt(index);
        }
        
        public void PrintCarriageList()
        {
            int i = 0;
            foreach (Carriage car in cars)
            {
                Console.WriteLine($"{i+1}: {car.ToString()}");
            }
        }

        protected int CarriageCount()
        {
            return cars.Count();
        }

        public override void Move()
        {
            Console.WriteLine($"Train #{Number} is moving");
            int i = 0;
            Console.WriteLine("{");
            foreach (Carriage car in cars)
            {
                if (car is PassengerCarriage)
                {
                    Console.WriteLine($"Carriage (passenger) #{i+1} is moving");
                }
                else
                {
                    Console.WriteLine($"Carriage (cargo) #{i+1} is moving");
                }
                i++;
            }
            Console.WriteLine("}");
        }

        public override string ToString()
        {
            string carriageCount = cars.Count switch
            {
                0 => "no carriages",
                1 => "1 carriage",
                _ => $"{cars.Count} carriages"
            };

            return $"Train #{Number}: {carriageCount}, Weight Capacity: {WeightCapacity}kg, Max Speed: {MaxSpeed} km/h, Current Speed: {CurSpeed} km/h";
        }
    }
}
