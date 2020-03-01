using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Triangle : GeometricFigure
    {
        private string privateString
        {
            get;
            set;
        }

        public Triangle(string name)
        {
            Name = name;
        }

        public void TestMethodWithParamm(string test)
        {
            Console.WriteLine(test + " " + Name);
        }
    }
}
