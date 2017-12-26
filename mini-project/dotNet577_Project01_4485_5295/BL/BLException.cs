using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BL
{
    [Serializable]
    public class BLException: Exception, ISerializable
    {
        public readonly string sender;

        public BLException() : base() { }
        public BLException(string message) : base(message) { }
        public BLException(string message, Exception inner) : base(message, inner) { }
        protected BLException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BLException(string message, string sender) : base(message)
        {
            this.sender = sender;
        }

        public override string ToString()
        {
            return "error occurred at " + sender + " function: " + Message;
        }
    }
}
