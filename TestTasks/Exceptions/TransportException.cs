using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Exceptions
{
    public class TransportException : Exception
    {
        public TransportException(string message):base(message)
        {

        }
    }
}
