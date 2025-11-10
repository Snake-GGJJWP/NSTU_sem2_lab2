using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Class
{
    internal class Train : Vehicle
    {
        private uint number; // train number
        private uint weightCapacity; // maximum carrying weight in kilograms
        private List<RailroadCar> cars = new List<RailroadCar>();

        public Train(uint number, uint capacity, uint maxSpeed, uint curSpeed = 0) : base(maxSpeed, curSpeed)
        {
            this.number = number;
            this.weightCapacity = capacity;
        }

        public void addCar(RailroadCar car)
        {
            // verification by weight
            cars.Add(car);
        }

        public void removeCar(int index) 
        {
            cars.RemoveAt(index);
        }

        public override void move()
        {
            Console.WriteLine("Train is moving");
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
