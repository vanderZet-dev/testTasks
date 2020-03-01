using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Exceptions;

namespace TestTasks.Models
{
    public class Car : Transport
    {
        public string FuelType { get; set; }

        public double MaxFuel { get; set; }
        private double availFuel;
        public double AvailFuel
        {
            get { return availFuel; }
            set
            {
                if (value > MaxFuel)
                {
                    availFuel = MaxFuel;
                }
                else availFuel = value;
            }
        }
        


        public bool EngineIsStarted { get; set; } = false;        

        public Car (string name, double maxSpeed, int passengerCapacity, string fuelType, double maxFuel)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            PassengerCapacity = passengerCapacity;
            FuelType = fuelType;
            MaxFuel = maxFuel;
        }

        public override void StartMoving ()
        {            

            if (!EngineIsStarted)
            {
                throw new TransportException("You can not start moving if engine is stoped.");
            }

            base.StartMoving();            
        }

        public virtual void StartEngine()
        {
            if (AvailFuel <= 0)
            {
                throw new TransportException("Cannot start engine. Check fuel indicator.");
            }
            EngineIsStarted = true;
            Console.WriteLine("Car Engine is succesfully started.");
        }

        public void StopEngine()
        {
            EngineIsStarted = false;
            Console.WriteLine("Car Engine is succesfully stoped.");
        }


        
    }
}
