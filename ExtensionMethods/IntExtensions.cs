using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingSystem.Services.Utilities;

namespace GradingSystem.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsCorrectOption<Type>(this int i)
        {
            return Enum.IsDefined(typeof(Type), i);
        }

        public static bool IsExit(this int i)
        {
            return i == (int)MainOptions.Exit;
        }
    }
}
