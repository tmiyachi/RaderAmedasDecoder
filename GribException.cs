using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaderAmedasDecoder
{
    class GribException : Exception
    {
        public GribException() { }

        public GribException(String message) : base(message) { }

        public GribException(String message, Exception inner) : base(message) { }
    }
}
