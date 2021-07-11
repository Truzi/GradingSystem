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
            return new GradeException("Either student/subject does not exist or this student does not have grades in this subject");
        }

        public static GradeException SearchError()
        {
            return new GradeException("There are no search results");
        }

        public static GradeException ValueError()
        {
            return new GradeException("There was an error with setting value\nValue must be number between 1 and 6");
        }

        public static GradeException NoStudentsOrSubjects()
        {
            return new GradeException("Table 'Students' and/or 'Subjects is currently empty\n");
        }

        public static GradeException AddError()
        {
            return new GradeException("Error occured while adding grade");
        }

        public static GradeException UpdateError()
        {
            return new GradeException("Error occured while updating grade");
        }

        public static GradeException RemoveError()
        {
            return new GradeException("Error occured while removing grade");
        }
    }
}
