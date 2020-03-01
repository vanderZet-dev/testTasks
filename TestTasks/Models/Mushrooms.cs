using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Mushrooms : IEnumerable
    {
        private List<Mushroom> items;

        public Mushrooms()
        {
            items = new List<Mushroom>();
            items.Add(new Mushroom("Белый гриб"));
            items.Add(new Mushroom("Шампиньены"));
            items.Add(new Mushroom("Вешанки"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Food> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
