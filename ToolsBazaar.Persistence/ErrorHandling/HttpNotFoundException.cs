using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToolsBazaar.Persistence.ErrorHandling
{
    public class HttpNotFoundException : Exception
    {
        public HttpStatusCode Status { get; private set; }

        public HttpNotFoundException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }
    }
}
