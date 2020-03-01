using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class GeometricFigures:IEnumerable
    {
        private List<GeometricFigure> items;

        public GeometricFigures()
        {
            items = new List<GeometricFigure>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<GeometricFigure> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void AddItem(GeometricFigure figure)
        {
            items.Add(figure);
        }
    }
}
