using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class Elipses: IEnumerable
    {
        private Elipse[] items;

        public Elipses()
        {
            items = new Elipse[2];
            items[0] = new Elipse("Окружность");
            items[1] = new Elipse("Овал");
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ElipseEnum GetEnumerator()
        {
            return new ElipseEnum(items);
        }
    }
}
