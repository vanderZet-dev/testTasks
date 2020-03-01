using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestTasks.Exceptions;

namespace TestTasks.Models
{
    public class UniqueCollection<T> : IEnumerable
    {
        private HashSet<T> items = new HashSet<T>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void AddItem(T newItem)
        {
            Console.WriteLine($"Попытка добавить элемент {newItem}");
            if (items.Contains(newItem))
            {
                throw new ItemIsAlreadyExistsException("Such item is already exists.");
            };
            items.Add(newItem);
        }

        public void Remove(T itemToRemove)
        {
            items.Remove(itemToRemove);
        }
    }
}
