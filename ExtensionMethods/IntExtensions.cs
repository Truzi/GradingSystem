using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GradingSystem.Services.Dependencies.OptionsEnum;

namespace GradingSystem.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsCorrectOption<Type>(this int i)
        {
            return Enum.IsDefined(typeof(Type), i);
        }
    }
}
