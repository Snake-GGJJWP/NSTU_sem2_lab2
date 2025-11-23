using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Class
{
    internal class CargoCarriage : Carriage
    {
        private uint loadWeight; // weight of the cargo itself (kg)
        private string cargoName; // i.e. Coal, Oil, Chemicals

        public uint LoadWeight 
        {
            get { return  loadWeight; }
            set 
            {
                if (value == 0) 
                {
                    throw new ArgumentException("Cargo weight cannot be less than zero");
                }
                loadWeight = value;
            }
        }

        public string CargoName 
        {
            get { return cargoName; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length > 40)
                    throw new ArgumentException("Cargo name length should be between 1 and 40 characters");
                cargoName = value;
            }
        }

        public CargoCarriage(uint baseWeight, uint loadWeight, string cargoName)
            : base(baseWeight)
        {
            LoadWeight = loadWeight;
            CargoName = cargoName;
        }

        public override uint TotalWeight()
        {
            return BaseWeight + LoadWeight;
        }

        public override string ToString()
        {
            return $"Carriage (cargo): {cargoName}, Load: {loadWeight} kg, Carriage weight: {BaseWeight} kg";
        }
    }
}
