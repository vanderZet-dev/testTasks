using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Berries : IEnumerable
    {
        private List<Berry> items;

        public Berries()
        {
            items = new List<Berry>();
            items.Add(new Berry("Малина"));
            items.Add(new Berry("Ежевика"));
            items.Add(new Berry("Смородина"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Berry> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
