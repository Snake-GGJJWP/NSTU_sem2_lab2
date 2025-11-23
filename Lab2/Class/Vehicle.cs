using System;

namespace Lab2.Class
{
    internal abstract class Vehicle
    {
        private uint curSpeed; // current speed
        private uint maxSpeed; // maximal speed
        private Engine engine;

        public uint CurSpeed
        {
            get { return curSpeed; }
            set
            {
                if (value > maxSpeed)
                    throw new ArgumentException("Current speed cannot be greater than maximum speed");
                curSpeed = value;
            }
        }

        public uint MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Maximum speed cannot be zero");
                maxSpeed = value;
            }
        }

        public Engine Engine
        {
            get { return engine; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Engine cannot be null");
                engine = value.Copy();
            }
        }

        public Vehicle(Engine engine, uint maxSpeed, uint curSpeed = 0) 
        {
            Engine = engine;
            MaxSpeed = maxSpeed;
            CurSpeed = curSpeed;
        }

        // Test method
        public abstract void Move();

        public abstract override string ToString();
    }
}
