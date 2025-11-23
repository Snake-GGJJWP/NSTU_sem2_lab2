using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2.Class
{
    enum CarriageClass
    {
        Econom = 0,
        Regular = 1,
        VIP = 2,
    }
    internal class PassengerCarriage : Carriage
    {
        const uint DEFAULT_PERSON_WEIGHT = 70;
        private CarriageClass carriageClass;
        private uint peopleCapacity;
        private bool hasWifi;

        public CarriageClass CarriageClass
        {
            get { return carriageClass; }
            set { carriageClass = value; }
        }

        public uint PeopleCapacity
        {
            get { return peopleCapacity; }
            set { peopleCapacity = value; }
        }

        public bool HasWifi
        {
            get { return hasWifi; }
            set { hasWifi = value; }
        }

        public PassengerCarriage(uint baseWeight, uint peopleCapacity, CarriageClass carriageClass, bool hasWifi = false) 
            : base (baseWeight) 
        {
            PeopleCapacity = peopleCapacity;
            CarriageClass = carriageClass;
            HasWifi = hasWifi;
        }

        public override uint TotalWeight() 
        {
            return BaseWeight + PeopleCapacity * DEFAULT_PERSON_WEIGHT;
        }

        public override string ToString()
        {
            string classString = carriageClass switch
            {
                CarriageClass.Econom => "Economy Class",
                CarriageClass.Regular => "Regular Class",
                CarriageClass.VIP => "VIP Class",
            };

            string wifiStatus = hasWifi ? "with WiFi" : "no WiFi";

            return $"Carriage (passenger): {classString}, Capacity: {peopleCapacity} people, WiFi: {wifiStatus}, Carriage weight: {BaseWeight} kg";
        }
    }
}
