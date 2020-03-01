using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class NumberAnalyzer
    {
        private double baseNumber;

        private double availDifferencePercent;
        public double AvailDifferencePercent
        {
            set { availDifferencePercent = value / 100.0; }
        }

        public NumberAnalyzer(double baseNumber, double availDifferencePercent)
        {
            this.baseNumber = baseNumber;
            AvailDifferencePercent = availDifferencePercent;
        }

        public delegate void TooHightDifference();
        public event TooHightDifference EventTooHightDifference;

        public void DifferenceChecker(double number)
        {
            double calculatedDifference = Math.Abs(1.0 - number / baseNumber);
            if (calculatedDifference > availDifferencePercent)
            {
                EventTooHightDifference?.Invoke();
            }
        }
    }
}
