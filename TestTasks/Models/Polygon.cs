using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Polygon : GeometricFigure, IComparable<Polygon>
    {
        public double Volume { get; set; }

        public Polygon(string name)
        {
            Name = name;
        }

        public Polygon(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }

        public int CompareTo(Polygon p)
        {
            return Volume.CompareTo(p.Volume);
        }

        public override string ToString()
        {
            return Name + ": объем " + Volume;
        }
    }
}
