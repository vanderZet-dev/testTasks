using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestTasks.Models
{
    public class CustomStack<T> : IEnumerable
    {
        protected List<T> items = new List<T>();

        private int limit;

        public CustomStack(int limit)
        {
            this.limit = limit;
        }
        
        public delegate void AddedNewItem();
        public event AddedNewItem EventAddedNewItem;

        public delegate void StackIsEmpty();
        public event StackIsEmpty EventStackIsEmpty;

        public delegate void LimitExceeded();
        public event LimitExceeded EventLimitExceeded;

        public void AddItem(T item)
        {
            items.Add(item);
            EventAddedNewItem?.Invoke();
            CheckForLimit();
        }

        public T GetNext(bool throwException = true)
        {
            if (items.Count <= 0)
            {
                if (throwException) throw new Exception("В данные момент, в очереди нет элементов.");
                else return default;
            }

            var item = items[0];
            items.Remove(item);
            CheckForEmpty();
            return item;
        }

        private void CheckForEmpty()
        {
            if (items.Count == 0)
            {
                EventStackIsEmpty?.Invoke();
            }
        }

        private void CheckForLimit()
        {
            if (items.Count >= limit)
            {
                EventLimitExceeded?.Invoke();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
