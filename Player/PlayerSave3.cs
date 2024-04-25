using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Player
{
    internal class PlayerSave3 : Players
    {
        internal override string GetPlayerName(string playerName)
        {
            Console.Write("Please enter your player name: ");
            playerName = Console.ReadLine();
            return playerName;
        }

        internal override string GetPlayerAge(string playerAge)
        {
            Console.Write("Please enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());
            if (age <= 11)
            {
                Game.Finish();
                return underAgeLimit;

            }
            else
            {
                playerAge = age.ToString();
                return playerAge;
            }
        }
    }
}
