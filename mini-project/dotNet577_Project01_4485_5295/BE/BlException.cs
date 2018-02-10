using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class BLException : Exception, ISerializable
    {
        /// <summary>
        /// the name of the function that throw the exception
        /// </summary>
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
