using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2.Class
{
    enum EngineType 
    { 
        Diesel = 0,
        Gasoline = 1,
        Electric = 2,
    }
    class Engine
    {
        private uint serialNumber;
        private string model; // mark of the engine
        private double volume; // in liters
        private double powerOutput; // in kilowatts
        private EngineType type;

        public uint SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 40)
                    throw new ArgumentException("Model name length should be between 1 and 40 characters");
                model = value;
            }
        }

        public double Volume
        {
            get { return volume; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Volume must be positive");
                volume = value;
            }
        }

        public double PowerOutput
        {
            get { return powerOutput; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Power output must be positive");
                powerOutput = value;
            }
        }

        public EngineType Type
        {
            get { return type; }
            set
            {
                if (value < EngineType.Diesel || value > EngineType.Electric)
                    throw new ArgumentException("Engine type must be in range [0;2] (Diesel, Gasoline, Electric)");
                type = value;
            }
        }
        public Engine(uint serialNumber, string model, double volume, double powerOutput, EngineType type) 
        {
            this.serialNumber = serialNumber;
            Model = model;
            Volume = volume;
            PowerOutput = powerOutput;
            Type = type;
        }

        public Engine Copy()
        {
            return (Engine)this.MemberwiseClone();
        }

        // Object methods

        public override bool Equals(object? obj)
        {
            if (obj is Engine eng)
            {
                // if serial number and model name is matching engine
                if (eng.serialNumber == this.serialNumber && eng.model.Equals(this.model))
                    return true;
                return false;
            }
            else
            {
                throw new ArgumentException("Incomparable types");
            }
        }

        public override int GetHashCode()
        {
            return $"{serialNumber}:{model}".GetHashCode();
        }

        public override string ToString()
        {
            return $"Engine (Serial Number: {serialNumber}; Model: {model}; Volume: {volume}L; Power: {powerOutput}kW; Type: {type})";
        }

        ~Engine()
        {
            Console.WriteLine($"Engine {model}:{serialNumber} has been destructed");
            GC.Collect(); // garbage collector will free memory I hope
        }
    }
}
