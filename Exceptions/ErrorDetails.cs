using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Exceptions
{
    public class Error2
    {
        public string domain { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
    }

    public class Error
    {
        public List<Error2> errors { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }

    public class ErrorDetails
    {
        public Error error { get; set; }
    }
}
