using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Exceptions
{
    [Serializable]
    public class GradeException: Exception
    {
        protected GradeException() { }
        protected GradeException(string message) : base(message) { }
        protected GradeException(string message, Exception innerException) : base(message, innerException) { }
        protected GradeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public static GradeException DbError()
        {
            return new GradeException("There was a problem with connection to DB");
        }

        public static GradeException NotFound()
        {
            return new GradeException("You provided wrong ID");
        }

        public static GradeException EmptyTable()
        {
            return new GradeException("Table 'Grades' is currently empty\n");
        }
    }
}
