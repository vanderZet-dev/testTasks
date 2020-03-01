using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Table
    {
        public string Material { get; set; }

        public int NumberOfLegs { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Sold { get; set; }

        public Table(string material, int numberOfLegs, DateTime createDate, bool sold)
        {
            Material = material;
            NumberOfLegs = numberOfLegs;
            CreateDate = createDate;
            Sold = sold;
        }

        public override string ToString()
        {
            return Material + " " + NumberOfLegs + " " + CreateDate + " " + Sold;
        }
    }
}
