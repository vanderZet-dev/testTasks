using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    public class ElipseEnum : IEnumerator
    {
        public Elipse[] Items;
        
        int position = -1;

        public ElipseEnum(Elipse[] list)
        {
            Items = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < Items.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public Elipse Current
        {
            get
            {
                try
                {
                    return Items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
