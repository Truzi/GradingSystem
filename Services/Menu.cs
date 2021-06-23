using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Services
{
    static class Menu
    {
        public const int repeat = 30;
        public static void MainMenu()
        {
            Console.WriteLine("GRADING SYSTEM");
            Console.WriteLine(new string('-', repeat));
            Console.WriteLine("1. Manage students");
            Console.WriteLine("2. Manage subjects");
            Console.WriteLine("3. Manage grades");
            Console.WriteLine("0. Exit the program");
            Console.WriteLine(new string('-', repeat));
        }

        public static void StudentMenu()
        {
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Update student");
            Console.WriteLine("3. Remove student");
            Console.WriteLine("4. Show students");
            Console.WriteLine("0. Exit to upper menu");
            Console.WriteLine(new string('-', repeat));
        }

        public static void SubjectMenu()
        {
            Console.WriteLine("1. Add subject");
            Console.WriteLine("2. Update subject");
            Console.WriteLine("3. Remove subject");
            Console.WriteLine("4. Show subjects");
            Console.WriteLine("0. Exit to upper menu");
            Console.WriteLine(new string('-', repeat));
        }

        public static void GradeMenu()
        {
            Console.WriteLine("1. Add grade");
            Console.WriteLine("2. Update grade");
            Console.WriteLine("3. Remove grade");
            Console.WriteLine("4. Show grades for one subject");
            Console.WriteLine("5. Show grades for one student");
            Console.WriteLine("6. Show grades for one student from one particular subject");
            Console.WriteLine("0. Exit to upper menu");
            Console.WriteLine(new string('-', repeat));
        }
    }
}
