using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Common.Exceptions
{
    public class WrongDataException : Exception
    {
        public WrongDataException(string message) : base(message)
        {
        }
    }
}