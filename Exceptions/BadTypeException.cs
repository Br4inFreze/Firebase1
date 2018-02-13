using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Exceptions
{
    class BadTypeException : Exception
    {
        public BadTypeException() { }
        public BadTypeException(string msg) : base(msg) { }
    }
}
