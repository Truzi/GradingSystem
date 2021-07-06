using GradingSystem.Services;
using System;
using System.Linq;
using static GradingSystem.Services.Dependencies.OptionsEnum;
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
                option = GradingSystemService.GetOption();
                GradingSystemService gradingSystemService = new();
                gradingSystemService.MainMenuHandler(option);
            } while (true);
        }
    }
}
