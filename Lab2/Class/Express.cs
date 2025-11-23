using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab2.Class
{
    internal class Express : Train
    {
        private bool hasPriorityRouting;
        private uint carriageCapacity; // assuming Express can't have more than a set amount of carriages
        
        public Express (uint carriageCapacity, bool hasPriorityRouting, uint number, uint capacity, Engine engine, uint maxSpeed, uint curSpeed = 0)
            : base (number, capacity, engine, maxSpeed, curSpeed)
        {
            this.carriageCapacity = carriageCapacity;
            this.hasPriorityRouting = hasPriorityRouting;
        }

        public override void AddCar(Carriage car)
        {
            if (CarriageCount() > carriageCapacity)
            {
                throw new OverflowException("Exceeded number of carrying carriages");
            }
            base.AddCar(car);
        }

        public override void RemoveCar(int index)
        {
            base.RemoveCar(index);
        }

        public override void Move()
        {
            Console.WriteLine($"Express #{Number} is moving");
        }

        public override string ToString()
        {
            string priorityStatus = hasPriorityRouting ? "with Priority Routing" : "no Priority Routing";

            return $"Express #{Number}: {CarriageCount()}/{carriageCapacity} carriages, {priorityStatus}, " +
                   $"Weight Capacity: {WeightCapacity}kg, Max Speed: {MaxSpeed} km/h, Current Speed: {CurSpeed} km/h";
        }
    }
}
