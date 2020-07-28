using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Common.Exceptions
{
    public class DataException : Exception
    {
        public DataException(string message) : base(message)
        {
        }
    }
}