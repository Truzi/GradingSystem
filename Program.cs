using GradingSystem.Services;
using System;
using System.Linq;
using GradingSystem.Services.Utilities;
using static GradingSystem.ExtensionMethods.IntExtensions;

namespace GradingSystem
{
    static class Program
    {
        

        static void Main()
        {
            int option;
            do
            {
                Menu.MainMenu();
                option = GradingSystemService.GetInt();
                GradingSystemService gradingSystemService = new();
                gradingSystemService.MainMenuHandler(option);
            } while (true);
        }
    }
}
