using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {
        internal override string CreateDescription() =>
@"You've made it to the living room!
You've completed the game! If you wish to continue wandering, type 'bedroom'...
Type anything else to end game.";


        internal override void ReceiveChoice(string choice)
        {
            if (choice == "bedroom")
            {
                Game.Transition<Bedroom>();
            }
            else
            {
                Game.Finish();
            }
        }
    }
}
