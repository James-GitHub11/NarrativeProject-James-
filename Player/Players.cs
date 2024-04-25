using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    
    internal abstract class Players
    {
        internal static int age;
        internal static string underAgeLimit = "You're too young to play this game. This contains thriller/horror themes.";
        internal abstract string GetPlayerName(string playerName);

        internal abstract string GetPlayerAge(string playerAge);
    }
}
