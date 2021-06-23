using GradingSystem.Services;
using System;
using System.Linq;

namespace GradingSystem
{
    static class Program
    {
        static void Main()
        {
            int option = 0;
            int[] options = { 0, 1, 2, 3 };
            GradingSystemService gradingSystem = new();
            do
            {
                Menu.MainMenu();
                do
                {
                    Console.Write("Provide an option (blank == exit): ");
                    option = GradingSystemService.GetOptionOrID();
                } while (!options.Contains(option));
                gradingSystem.MainMenuHandler(option);
            } while (true);
        }
    }
}
