using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Triangles : IEnumerable
    {
        private List<Triangle> items;

        public Triangles()
        {
            items = new List<Triangle>
            {
                new Triangle("Равнобедренный"),
                new Triangle("С прямым углом"),
                new Triangle("Равносторонний")
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Triangle> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
