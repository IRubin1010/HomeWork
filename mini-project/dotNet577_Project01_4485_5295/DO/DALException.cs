using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class DALException : Exception, ISerializable
    {
        /// <summary>
        /// the name of the function that throw the exception
        /// </summary>
        public readonly string sender;

        public DALException() : base() { }
        public DALException(string message) : base(message) { }
        public DALException(string message, Exception inner) : base(message, inner) { }
        protected DALException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DALException(string message, string sender) : base(message)
        {
            this.sender = sender;
        }

        public override string ToString()
        {
            return "error occurred at " + sender + " function: " + Message;
        }

    }
}
