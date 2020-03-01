using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class PolygonComparer : IComparer<Polygon>
    {
        public int Compare(Polygon p1, Polygon p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            else if (p1.Name.Length < p2.Name.Length)
                return -1;
            else
                return 0;
        }
    }
}
