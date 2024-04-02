using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {
        //internal static bool goneDownstairs = false;
        internal override string CreateDescription() =>
@"You've open the door, gone downstairs and made it to the living room!
You hear a loud noise coming from the furnace room.
However, all the lights are off on the main floor...
What's your next move: Follow the noises in the [furnace room]?
Or return upstairs to the [bedroom]?";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bedroom":
                    {
                        Game.Transition<Bedroom>();
                    }break;
                        
                case "furnace room":
                    {
                        Game.Transition<FurnaceRoom>();
                    }break;
                    
            }                 
            
        }
    }
}
