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
        internal static bool isPlayerBleedingOut = false;
        internal static bool isCheckPointAchieved = false;
        internal static int mouseTrapInitialDamage = 100;
        internal override string CreateDescription()
        {
//            if (ElectricalRoom.electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == true && ElectricalRoom.alarmTrigerred == false)
//            {
//                return
//@"Checkpoint achieved!
//The room seems to be getting warmer now and you're no longer shivering.
//With the cold no longer a distraction, the electricity running, and alarm turned off, you can finally focus all your efforts on escape!";
//            }
            if (isCheckPointAchieved == true)
            {
                return
@"You walk back a bit towards to the center area of the living room.
Doesn't seem like there's much left to do here.

If you'd like to look around more, then you can explore the following rooms still:
1) Go to [electrical room]?
2) Go to [furnace room]?
3) Go to [bedroom]?
4) Inspect [notepad]?
5) Watch the [news]?
5) Return towards extended area of [living room] near the sliding door?";
            }
            if (ElectricalRoom.electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == true && ElectricalRoom.alarmTrigerred == true)
            {
                return
@"You're in the living room. Your no longer freezing to death.
However, if the alarm keeps going off, your window for escape will keep getting smaller!
(Hint: find the correct circuit breaker numbers for the power, or find the switch number that controls the alarm!)

What's your next move?
1) Return to the [electrical room]?
2) Try the [front door]?
3) Return upstairs to the [bedroom]?
4) Return to the [furnace room]?";
            }

            if (Bedroom.isFlashLightInventoried == true && FurnaceRoom.isFurnaceFixed == false && performedLivingRoomScan == false)
            {
                return
@"You're in the living room, and it's still too cold for comfort.
The furnace room is still making odd noises.
Being alone in this eerie old house is seriously starting to give you the creeps.
The alarming sense of danger forces you to panic, with every instinct in your body urging you to escape ASAP.
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
Your flashlight reveals 2 doorways.. the one leading the furnace room, and a mystery door next to it.

What's your next move?
1) Head towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Escape through the [front door]?
4) Try opening the [mystery] door?";
            }

            if (ElectricalRoom.performedElectricalRoomScan == true && FurnaceRoom.isFurnaceFixed == false && ElectricalRoom.electricityTurnedOn == false)
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
The power is on and you can finally see everything in the room.
Specifically, you notice a notepad on the coffee table.
The old TV also turns back on, playing the local news channel. 
However, you're still shivering from the cold.

What's your next move? 
1) Head towards the [furnace room]?
2) Return upstairs to the [bedroom]?
3) Inspect the [notepad] seen on the coffee table.
4) Watch the [news] playing on the TV?
5) Return to [electrical room]";
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
                case "living room":
                    {
                        if (isCheckPointAchieved == true)
                        {
                            Game.Transition<LivingRoom2>();
                        }
                        else
                        {
                            Game.Transition<LivingRoom>();
                        }
                    }break;

                case "bedroom":
                    {
                        Game.Transition<Bedroom>();
                    }break;
                        
                case "furnace room":
                    {
                        if (performedLivingRoomScan == false)
                        {
                            isPlayerBleedingOut = true;
                            Game.hp -= mouseTrapInitialDamage;
                            mouseTrapInitialDamage = 0;
                            Console.WriteLine("You fumble through the dark room, taking long steps to avoid any unseen objects.\nAfter only making it a few steps, you feel an intense pain rushing to your foot." +
                                "\nYou've stepped on a long nail that was sticking out of the floorboard. Your foot is badly wounded.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You'll bleed out if you don't tend to your wound ASAP!");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(Hint: search the house for bandages or anything to wrap your wound)");
                            Console.ForegroundColor = ConsoleColor.White;
                            Game.Transition<LivingRoom>();
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
                        Console.WriteLine("The notebook has a hand-drawn sketch of a roulette wheel with the number 11 circled, and a quote saying 'AlWAYS bet on red'.");
                        Console.WriteLine("'Hmm.. that's strange. If I remember correctly, #11 is a black number on the roulette wheel? Seems a bit contradictory of him?'");
                        //if notepad is selected, it will open up an image of the notepad with a graphic of a roulette table and the hint to always bet on red.
                        Game.Transition<LivingRoom>();
                    }break;

                case "news":
                    {
                        Console.WriteLine("As you begin listening, you hear extreme weather warnings for an incoming hurricane, urging everyone to stay inside.");
                        //add photo of the TV playing news
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

                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<ElectricalRoom>();
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Invalid command.");
                    }
                    break;
            }                 
            
        }
    }
}
