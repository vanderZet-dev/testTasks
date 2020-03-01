using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Bicycle: Transport, ICloneable
    {   

        public Bicycle(string name, double maxSpeed, int passengerCapacity)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            PassengerCapacity = passengerCapacity;            
        }

        public Bicycle(string name, double maxSpeed, int passengerCapacity, Driver transportDriver)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            PassengerCapacity = passengerCapacity;
            TransportDriver = transportDriver;
        }

        public object Clone()
        {
            Driver clonedDriver = null;
            if (TransportDriver != null)
            {
                clonedDriver = new Driver(TransportDriver.Name);
            }
            return new Bicycle(Name, MaxSpeed, PassengerCapacity, clonedDriver);
        }
    }
}
