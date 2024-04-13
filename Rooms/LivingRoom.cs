using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {
        //internal static bool goneDownstairs = false;
        internal static bool electricityTurnedOn = false;
        internal override string CreateDescription()
        {
            if (Bedroom.isFlashLightInventoried == true && FurnaceRoom.isFurnaceFixed == false)
            {
                return
@"You're in the living room, it's still cold.
You point your flashlight towards the dripping noises you've been hearing, and just barely spot the doorway to the furnace room.
Feeling a bit creeped out, you scan more of the room with your flashlight and notice a mystery door leading to an unknown room.

What's your next move? 
1) Head towards the noises in the [furnace room]?
2) Try turning on the [light switch]?
3) Return upstairs to the [bedroom]?
4) Try the [mystery door]?";
            }
            if (electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == false)
            {
                return
@"You're in the living room again.
With the electricity running and lights now turned on, you start to notice some of the objects you previously didn't see, in the living room.
Specifically, you notice a notepad on the coffee table.
However, you're still shivering from the cold.

What's your next move? 
1) Head back towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Inspect the [notepad] seen on the coffee table.";
            }
            //The furnace seems to be working now and you're no longer cold.
            //With the cold no longer a distraction, and your flashlight lighting the way, you notice two more doors.
            else
            {
                return
@"You walk down a dark and narrow hallway, managing to find the stairs down to the living room.
However, you notice all the lights are off on the main floor and it's freezing cold...
You also start hearing weird noises coming from the furnace room.
There's a light-switch to your right.

What's your next move? 
1) Follow the noises in the [furnace room]?
2) Try turning on the [light switch]
3) Return upstairs to the [bedroom]?";
            }
            
        }


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
                case "light switch":
                    {
                        if (electricityTurnedOn == false)
                        {
                            Console.WriteLine("This switch does not work. Hmm, maybe the power is out?");
                            Game.Transition<LivingRoom>();
                        }
                        else if (electricityTurnedOn == true)
                        {
                            Console.WriteLine("You flip the switch and finally the lights turn on.");
                            Game.Transition<LivingRoom>();
                        }
                    }break;
                case "mystery door":
                    {
                        Game.Transition<ElectricRoom>();
                        //will lead to the electric room
                    }break;
                case "door 2:":
                    {
                        //will lead to the garage
                    }break;
                case "notepad":
                    {
                        //if notepad is selected, it will open up an image of the notepad with a graphic of a roulette table and the hint to always bet on red.
                    }break;
                    
            }                 
            
        }
    }
}
