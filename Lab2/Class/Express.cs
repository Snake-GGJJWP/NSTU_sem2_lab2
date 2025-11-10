using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Class
{
    internal class Express : Train
    {
        private uint name;
        private uint peopleCapacity; // new field
        
        public Express (uint name, uint peopleCapacity, uint number, uint capacity, uint maxSpeed, uint curSpeed = 0)
            : base (capacity, maxSpeed, curSpeed)
        {
            this.name = name;
            this.peopleCapacity = peopleCapacity;
        }
    }
}
