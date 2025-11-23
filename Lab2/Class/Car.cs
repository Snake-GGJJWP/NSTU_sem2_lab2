using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Class
{
    enum Drive
    {
        FWD = 0,
        RWD = 1,
        AWD = 2,
        _4WD = 3,
    }
    internal sealed class Car : Vehicle
    {
        private string mark;
        private Drive drive;

        public Car(string mark, Drive drive, Engine engine, uint maxSpeed, uint curSpeed = 0)
            : base(engine, maxSpeed, curSpeed)
        { 
            this.mark = mark; 
            this.drive = drive;
        }

        public override void Move()
        {
            Console.WriteLine($"{this.mark} is moving");
        }

        public override string ToString()
        {
            string driveString = drive switch
            {
                Drive.FWD => "Front-Wheel Drive",
                Drive.RWD => "Rear-Wheel Drive",
                Drive.AWD => "All-Wheel Drive",
                Drive._4WD => "Four-Wheel Drive",
                _ => "Unknown Drive"
            };

            return $"Car: {mark}, Drive: {drive}, Engine: {Engine}, Max Speed: {MaxSpeed}, Current Speed: {CurSpeed}";
        }
    }
}
