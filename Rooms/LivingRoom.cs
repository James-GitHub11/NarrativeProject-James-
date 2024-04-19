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
        internal override string CreateDescription()
        {
            if (ElectricalRoom.electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == true)
            {
                return
@"Checkpoint achieved!
The room seems to be getting warmer now and you're no longer shivering.
With the cold no longer a distraction, and the power turned on, you can focus all your effort on escape!";
            }
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
            if (ElectricalRoom.performedElectricalRoomScan == false && FurnaceRoom.isFurnaceFixed == false && performedLivingRoomScan == true)
            {
                return
@"You're in the living room, still freezing cold and trembling with angst and fear.
Down another small hallway, you can see what appears to be the front door of the house.
Now, you can also properly see the doorway that leads to the furnace room.
Your flashlight reveals another mysterious door, next to the furnace room.

What's your next move?
1) Head towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Escape through the [front door]?
4) Try opening the [mystery] door?";
            }

            if (ElectricalRoom.performedElectricalRoomScan == true && FurnaceRoom.isFurnaceFixed == false && performedLivingRoomScan == true)
            {
                return
@"You're in the living room, still freezing cold and trembling with angst and fear.
Down another small hallway, you can see what appears to be the front door of the house.
You see the doorway that leads to the furnace room.
Next to the furnace room, you see the door to the electrical room.

What's your next move?
1) Head towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Escape through the [front door]?
4) Return to the [electrical room]?";
            }

            if (ElectricalRoom.electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == false)
            {
                return
@"You're in the living room.
With the electricity running and lights now turned on, you start to notice more objects that you previously didn't see with your flashlight, in the living room.
Specifically, you notice a notepad on the coffee table.
However, you're still shivering from the cold.

What's your next move? 
1) Head towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Inspect the [notepad] seen on the coffee table.
4) Return to [electrical room]";
            }
            //The furnace seems to be working now and you're no longer cold.
            //With the cold no longer a distraction, and your flashlight lighting the way, you notice two more doors.
            else
            {
                return
@"You're in the living room...
However, all the lights are off on the main floor and it's freezing cold...
You can also hear weird noises coming from the furnace room.
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
                        if (performedLivingRoomScan == false)
                        {
                            Console.WriteLine("Attempting to be careful, you fumble through the dark room taking long steps to avoid any unseen objects.\nHowever, after only making it a few steps, you feel a sudden surge of pain rushing to your feet." +
                                "\nYou've stepped on a long nail that was sticking out of the floorboard and your foot is badly wounded.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("You're going to bleed out if you don't tend to your wounds ASAP!");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" (Hint: search the house for a bandages or something to wrap your wound)");
                            Console.ForegroundColor = ConsoleColor.White;
                            Game.Transition<Bedroom>();
                        }
                        else if (performedLivingRoomScan == true)
                        {
                            Game.Transition<FurnaceRoom>();
                        }
                        
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
                case "mystery":
                    {
                        Console.WriteLine("You open the mysterious door and take a step into the room.");
                        Game.Transition<ElectricalRoom>();
                        //will lead to the electric room
                    }break;
                case "electrical room":
                    {
                        Game.Transition<ElectricalRoom>();
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
                        Console.WriteLine("You turn your flashlight on, scanning your surroundings for an exit or anything useful to you.\nThe faint light of your flashlight reveals a few new things.");
                        performedLivingRoomScan = true;
                        Game.Transition<LivingRoom>();
                    }break;
                case "front door":
                    {
                        Console.WriteLine("You turn the lock and try opening the door, but it won't budge...");
                        Console.WriteLine("'Is this a sick joke? Did someone barricade this door or is it just busted?'");
                        Console.WriteLine("'Either way, this is seriously starting to scare me. I need to find another way out...'");
                        Game.Transition<LivingRoom>();
                    }break;
                default:
                    {
                        Console.WriteLine("Invalid command.");
                    }
                    break;
            }                 
            
        }
    }
}
