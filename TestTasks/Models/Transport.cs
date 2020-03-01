using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Models.Enums;

namespace TestTasks.Models
{
    public abstract class Transport
    {        
        public TransportCurrentState MechanicTransportCurrentState { get; set; } = TransportCurrentState.STOPED;
                
        public string Name { get; set; }
        
        public double MaxSpeed { get; set; }
        
        public int PassengerCapacity { get; set; }

        public Driver TransportDriver { get; set; }

        
        public virtual void StartMoving ()
        {
            MechanicTransportCurrentState = TransportCurrentState.MOVING;
            Console.WriteLine("Transport is start moving.");
        }
        
        protected void StopMoving()
        {
            MechanicTransportCurrentState = TransportCurrentState.STOPED;
            Console.WriteLine("Transport is stop moving.");
        }

        public override string ToString()
        {
            return "Класс: " + GetType().Name + Environment.NewLine +
                "Наименование: " + Name + Environment.NewLine +
                "Максимальная скорость: " + MaxSpeed + Environment.NewLine +
                "Пассажировместимость: " + PassengerCapacity + Environment.NewLine +
                "Водитель: " + (TransportDriver == null ? "Н/Д" : TransportDriver.Name);
        }
    }
}
