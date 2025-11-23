using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Class
{
    internal abstract class Carriage
    {
        private uint baseWeight; // mass of the carriage itself (kg)

        public uint BaseWeight 
        {
            get { return baseWeight; }
            set 
            {
                if (value == 0) 
                {
                    throw new ArgumentException("Carriage weight can't be zero");
                }
                baseWeight = value;
            } 
        }

        public Carriage(uint baseWeight)
        { 
            BaseWeight = baseWeight;
        }

        public abstract override string ToString();
        public abstract uint TotalWeight();
    }
}
