using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Exceptions;

namespace TestTasks.Models
{
    public class CarWithElectronic : Car
    {

        public CarWithElectronic(string name, double maxSpeed, int passengerCapacity, string fuelType, double maxFuel) : base(name, maxSpeed, passengerCapacity, fuelType, maxFuel)
        {

        }

        public override void StartEngine()
        {
            Console.WriteLine("Initial starting engine with simple mode.");
            checkElectronicalSystems();
            base.StartEngine();
        }

        public void ForcedStartEngine()
        {
            Console.WriteLine("Initial starting engine with forced mode.");
            base.StartEngine();
        }

        private void checkElectronicalSystems()
        {
            int electronicalSystemState = new Random().Next(0, 5);
            if (electronicalSystemState < 3)
            {
                throw new TransportException(string.Format("Electronical system find important problems. State id only {0}. Now you can not start your engine before fix it.", electronicalSystemState));
            }            
            Console.WriteLine("Electronical system state is {0}. Engine is avail to start.", electronicalSystemState);            
        }

    }
}
