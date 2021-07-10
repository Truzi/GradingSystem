using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Exceptions
{
    [Serializable]
    public class SubjectException : Exception
    {
        protected SubjectException() { }
        protected SubjectException(string message) : base(message) { }
        protected SubjectException(string message, Exception innerException) : base(message, innerException) { }
        protected SubjectException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public static SubjectException DbError()
        {
            return new SubjectException("Error with connection to DB");
        }

        public static SubjectException NotFound()
        {
            return new SubjectException("You provided wrong ID");
        }

        public static SubjectException EmptyTable()
        {
            return new SubjectException("Table 'Subjects' is currently empty\n");
        }

        public static SubjectException AddError()
        {
            return new SubjectException("Error occured while adding new subject. Check if subject with same name exists already");
        }

        public static SubjectException UpdateError()
        {
            return new SubjectException("Error occured while updating subject. Check if subject with same name exists already");
        }

        public static SubjectException RemoveError()
        {
            return new SubjectException("Error occured while removing subject");
        }
    }
}
