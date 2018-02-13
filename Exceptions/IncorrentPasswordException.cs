using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Exceptions
{
    public class IncorrentPasswordException : Exception
    {
        public IncorrentPasswordException() { }
        public IncorrentPasswordException(string msg) : base(msg) { }
    }
}
