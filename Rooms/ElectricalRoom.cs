using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal abstract class ElectricalRoom : Room
    {
        internal static bool performedElectricalRoomScan = false;
        internal static bool electricityTurnedOn = false;
        internal override string CreateDescription()
        {
            if (performedElectricalRoomScan == false && electricityTurnedOn == false)
            {
                return
@"You open the mysterious door and take a step into the room.
It's essentially pitch black in there, but you hear some whirring noises ahead of you.
Scared of what's in there, yet also curious, you ponder for a moment before acting.

What's your next move?
1) Return to the [living room]?
2) Continue forward to [explore] the whirring noises?
3) Use your flashlight to [scan] the room?";
            }
            if (performedElectricalRoomScan == true && electricityTurnedOn == false)
            {
                return
@"You take a step into the electrical room.
It's dark, but your flashlight is leading the way towards the whirring noises ahead of you.
You see a circuit breaker in front of you, with most of the circuits switched off.
You are unsure which switches controls the main floor of the house.

What's your next move?
1) Return to the [living room]?
2) Try flipping all the [switches]?
3) Use your flashlight to [scan] the room?";
            }
            else
            {
                return
@"There's nothing left to accomplish here. No new useful items here neither.
Next move:
Return to the [living room].";
            }
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "living room":
                    {
                        Game.Transition<LivingRoom>();
                    }break;
                case "scan":
                    {
                        performedElectricalRoomScan = true;
                        Console.WriteLine("You scan the room with your flashlight, and realize your standing in the electrical room.");
                        Game.Transition<ElectricalRoom>();
                    }break;
                case "explore":
                    {
                        Console.WriteLine("You take a few steps forward, then... 'OUCH!!'");
                        Console.WriteLine("You stepped on a mouse-trap and cut your toe badly.");
                        Game.Transition<ElectricalRoom>();
                    }break;
                case "switches":
                    {
                        
                        Game.Transition<ElectricalRoom>();
                    }break;
            }
        }
    }
}
