using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Exceptions
{
    public class EmailNotExistException : Exception
    {
        public EmailNotExistException() { }
        public EmailNotExistException(string msg) : base(msg) { }
    }
}
