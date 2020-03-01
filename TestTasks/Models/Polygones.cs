using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Polygones : IEnumerable
    {
        private List<Polygon> items;

        public Polygones()
        {
            items = new List<Polygon>
            {
                new Polygon("Квадрат"),
                new Polygon("Прямоугольник"),
                new Polygon("Трапеция")
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Polygon> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        
    }
}
