using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Exceptions
{
    public class ItemIsAlreadyExistsException : Exception
    {
        public ItemIsAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
