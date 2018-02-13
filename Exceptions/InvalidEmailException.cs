using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string msg) : base(msg) { }
    }
}
