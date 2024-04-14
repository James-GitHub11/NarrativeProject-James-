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
        //internal static bool electricityTurnedOn = false;
        internal static bool performedLivingRoomScan = false;
        internal static bool discoveredElectricalRoom = false;
        internal override string CreateDescription()
        {
            if (Bedroom.isFlashLightInventoried == true && FurnaceRoom.isFurnaceFixed == false && performedLivingRoomScan == false)
            {
                return
@"You're in the living room, and it's still too cold for comfort.
You can still hear odd noises coming from the furnace room.
Being alone in this eerie old house is seriously starting to give you the creeps.
This alarming sense of danger forces you into a panic, with every instinct in your body urging you to escape ASAP.
Feeling your heart pounding, you take a deep breath and think of your next course of action.

What's your next move? 
1) Head towards the [furnace room]?
2) Try turning on the [light switch]?
3) Return upstairs to the [bedroom]?
4) Use your flashlight to [scan] the room?";
            }
            if (Bedroom.isFlashLightInventoried == true && FurnaceRoom.isFurnaceFixed == false && performedLivingRoomScan == true)
            {
                return
@"You're in the living room, still freezing cold, and trembling with angst and fear.
You turn your flashlight on, scanning your surroundings for an exit or anything useful to you.
The faint light of your flashlight reveals a few new things.
Down another small hallway, you can see what appears to be the front door of the house.
Now, you can also properly see the doorway that leads to the furnace room.
Your flashlight reveals another mysterious door, next to the furnace room.

What's your next move?
1) Head back towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Escape through the [front door]?
4) Try opening the [mystery door]?";
            }

                if (ElectricalRoom.electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == false)
            {
                return
@"You're in the living room.
With the electricity running and lights now turned on, you start to notice more objects that you previously didn't see with your flashlight, in the living room.
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
                        if (ElectricalRoom.electricityTurnedOn == false)
                        {
                            Console.WriteLine("This switch does not work. Hmm, maybe the power is out?");
                            Game.Transition<LivingRoom>();
                        }
                        else if (ElectricalRoom.electricityTurnedOn == true)
                        {
                            Console.WriteLine("You flip the switch and finally the lights turn on.");
                            Game.Transition<LivingRoom>();
                        }
                    }break;
                case "mystery door":
                    {
                        discoveredElectricalRoom = true;
                        Game.Transition<ElectricalRoom>();
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
                case "scan":
                    {
                        performedLivingRoomScan = true;
                        Game.Transition<LivingRoom>();
                    }break;
                case "front door":
                    {
                        Console.WriteLine("You turn the lock and try opening the door, but it won't budge...");
                        Console.WriteLine("'Is this is a sick joke? Is the door barricaded or just busted?'");
                        Console.WriteLine("'Either way, this is seriously starting to scare me. I need to find a way out...'");
                        Game.Transition<LivingRoom>();
                    }break;
                    
            }                 
            
        }
    }
}
