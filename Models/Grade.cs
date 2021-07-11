namespace GradingSystem.Models
{
    class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } 

        public Grade(int value, string comment, int studentId, int subjectId)
        {
            Value = value;
            Comment = comment;
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
