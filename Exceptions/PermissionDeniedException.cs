using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Exceptions
{
    public class PermissionDeniedException : Exception
    {
        public PermissionDeniedException()
        { }
        public PermissionDeniedException(string msg) : base(msg) { }
    }
}
