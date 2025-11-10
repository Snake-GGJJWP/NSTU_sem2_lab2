using System;

namespace Lab2.Class
{
    internal abstract class Vehicle
    {
        private uint curSpeed; // current speed
        private uint maxSpeed; // maximal speed
        private Engine engine = new Engine("---", 1, 40, EngineType.Diesel);
        public Vehicle(uint maxSpeed, uint curSpeed = 0) 
        { 
            this.maxSpeed = maxSpeed;
            this.curSpeed = curSpeed;
        }

        // Test method
        public abstract void move();

        public abstract override string ToString();
    }
}
