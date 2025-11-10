using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string model; // mark of the engine
        private uint volume; // in liters
        private uint powerOutput; // in kilowatts
        private EngineType type;
        
        public string Model
        {
            get { return model; }
            set 
            {
                if (model.Length == 0 || model.Length > 40) 
                    throw new ArgumentException("Model name length should not exceed 40 symbols or be empty");
                model = value; 
            }
        }
        public Engine(string model, uint volume, uint powerOutput, EngineType type) 
        {
            this.model = model;
            this.volume = volume;
            this.powerOutput = powerOutput;
            this.type = type;
        }

        // To be overriden (i hate it)
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "";
        }

        ~Engine()
        {

        }
    }
}
