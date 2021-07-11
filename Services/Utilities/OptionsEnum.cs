namespace GradingSystem.Services.Utilities
{

    public enum MainOptions
    {
        Exit, Students, Subjects, Grades
    }

    public enum StudentOptions
    {
        Add = 1, Update, Remove, Print
    }

    public enum SubjectOptions
    {
        Add = 1, Update, Remove, Print
    }

    public enum GradeOptions
    {
        AccessStudent = 1, AccessSubject
    }

    public enum GradeStudentOptions
    {
        AddGrade = 1, UpdateGrade, RemoveGrade, PrintAllGrades, PrintGrades
    }
    
    public enum GradeSubjectOptions
    {
        AddGrades = 1, PrintGrades
    }
}
