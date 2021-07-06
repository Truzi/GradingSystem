using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Exceptions
{
    [Serializable]
    public class GradingSystemException : Exception
    {
        protected GradingSystemException() { }
        protected GradingSystemException(string message) : base(message) { }
        protected GradingSystemException(string message, Exception innerException) : base(message, innerException) { }
        protected GradingSystemException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public static GradingSystemException GetOption()
        {
            return new GradingSystemException("There was an error while fetching option from user. Probably mistyped.");
        }
    }
}
