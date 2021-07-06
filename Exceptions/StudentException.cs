using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Exceptions
{
    [Serializable]
    public class StudentException : Exception
    {
        protected StudentException() { }
        protected StudentException(string message) : base(message) { }
        protected StudentException(string message, Exception innerException) : base(message, innerException) { }
        protected StudentException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public static StudentException DbError()
        {
            return new StudentException("Error with connection to DB");
        }

        public static StudentException NotFound()
        {
            return new StudentException("You provided wrong ID");
        }

        public static StudentException EmptyTable()
        {
            return new StudentException("Table 'Students' is currently empty\n");
        }

        public static StudentException AddError()
        {
            return new StudentException("Error while adding new student");
        }

        public static StudentException UpdateError()
        {
            return new StudentException("Error while updating student");
        }

        public static StudentException RemoveError()
        {
            return new StudentException("Error while removing student");
        }
    }
}
