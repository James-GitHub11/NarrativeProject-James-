using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class ElectricalRoom : Room
    {
        internal static bool performedElectricalRoomScan = false;
        internal static bool electricityTurnedOn = false;
        internal static bool alarmTrigerred = false;
        internal static int alarmBreakerNumber = 11;
        internal static int counter = 0;
        internal static int response;
        internal static bool stuckInMouseTrap = false;
        internal static string circuitBreakerNumbers = "4, 8, 15, 16, 23, 42";
        internal static string circuitNumbersWithAlarm = "4, 8, 11, 15, 16, 23, 42";
        internal static bool isCircuitBreakerInspected = false;
        internal static string playerSwitchInput;
        internal static int circuitAttemptCounter = 0;
        internal override string CreateDescription()
        {
            if (electricityTurnedOn == true && alarmTrigerred == false) //rdescription for when the player has successfully turned the power on,
            {
                return
@"There's nothing left to accomplish here. No new useful items here neither.
Next move:
Return to the [living room].";
            }
            if (alarmTrigerred == true)
            {
                return
@"The alarm won't stop until you turn off all the switches, or figure out which one controls the alarm.
'It's good to finally have the power and lights on, but if this alarm keeps going off, whoever brought me here is sure to be back soon...'

What's your next move?
1) Return to the [living room]?
2) Turn [off all] of the switches?
3) Enter the breaker switch [#] that you want to turn off?";
            }
            if (performedElectricalRoomScan == true && electricityTurnedOn == false && isCircuitBreakerInspected == false)
            {
                return
@"In the electrical room, it's dark, but you point your flashlight towards the whirring noises.
You see a circuit breaker straight ahead, with most of the switches turned off.
You are unsure which switch (or switches) control the main floor of the house.

What's your next move?
1) Return to the [living room]?
2) Try flipping all the [switches]?
3) Focus your flashlight closer in on the [circuit breaker]?";
            }

            if (performedElectricalRoomScan == true && electricityTurnedOn == false && isCircuitBreakerInspected == true)
            {
                return
@"In the electrical room, it's dark, but you point your flashlight towards the whirring noises.
You see a circuit breaker straight ahead, with most of the switches turned off.
You are unsure which switch (or switches) control the main floor of the house.

What's your next move?
1) Return to the [living room]?
2) Try flipping all the [switches]?
3) Enter the [numbers] that control the main power?";
            }

            else
            {
                return
@"It's essentially pitch black in there, but you hear some whirring noises ahead of you.
Scared of what's in there, yet also curious, you ponder for a moment before acting.

What's your next move?
1) Return to the [living room]?
2) Continue forward to [explore] the whirring noises?
3) Use your flashlight to [scan] the room?"; 
            }
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "living room":
                    {
                        if (alarmTrigerred == false && electricityTurnedOn == true && FurnaceRoom.isFurnaceFixed == true)
                        {
                            Console.WriteLine("Checkpoint achieved!\nThe room seems to be getting warmer now and you're no longer shivering.\nWith the cold no longer a distraction, the electricity running, and alarm turned off, you can finally focus all your efforts on escape!");
                            LivingRoom.isCheckPointAchieved = true;
                            Game.hp = +100;
                            Game.Transition<LivingRoom2>(); //will have to be LivingRoom2 actually once i make that room
                        }
                        else if (alarmTrigerred == true && electricityTurnedOn == true)
                        {
                            Game.Transition<LivingRoom>();
                        }
                        else
                        {
                            Game.Transition<LivingRoom>();
                        }
                    }break;
                case "numbers":
                    {
                        Console.WriteLine("Please enter the correct sequence of numbers (separated by a comma) for the power switches (careful, one of the switches turns on the alarm system!)");
                        playerSwitchInput = Console.ReadLine();
                        if (playerSwitchInput == circuitBreakerNumbers)
                        {
                            Console.WriteLine("I think these switches did the trick!' You succesfully turn the power on, without triggering the alarm.");
                            electricityTurnedOn = true;
                            alarmTrigerred = false;
                        }
                        if (playerSwitchInput == circuitNumbersWithAlarm)
                        {
                            Console.WriteLine("You flip all the switches. Finally the power is running all throughout the house.\nHowever... the house-alarm is immediately triggered, blaring as loud as ever.");
                            alarmTrigerred = true;
                            electricityTurnedOn = true;
                            Game.Transition<ElectricalRoom>();
                        }
                        else if (circuitBreakerNumbers != playerSwitchInput)
                        {
                            Console.WriteLine("These switches did NOT work! (make sure to turn them on in the right order)");
                            circuitAttemptCounter++;
                            if (circuitAttemptCounter >= 1)
                            {
                                Console.WriteLine("Hint: There are only 6 switches/numbers that need to be turned on (in the correct order). ");
                            }
                        }
                        break;
                    }

                case "scan":
                    {
                        performedElectricalRoomScan = true;
                        Console.WriteLine("You scan the room with your flashlight, and realize your standing in the electrical room.");
                        Console.WriteLine("You spot a bunch of mouse traps laid out on the floor in front of you, which you carefully move out of your path.");
                        Game.Transition<ElectricalRoom>();
                    }break;

                case "explore":
                    {
                        Console.WriteLine("You take a few steps forward, then... 'OUCH!!'");
                        Console.WriteLine("You've stepped on a mouse-trap and cut your toe badly.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You'll bleed out if you don't tend to your wound ASAP!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("(Hint: search the house for bandages or anything to wrap your wound)");
                        Console.ForegroundColor = ConsoleColor.White;
                        stuckInMouseTrap = true;
                        Game.hp -= 50;
                        Game.Transition<ElectricalRoom>();
                    }break;

                case "switches":
                    {
                        Console.WriteLine("You flip all the switches. Finally the power is running all throughout the house.\nHowever... the house-alarm is immediately triggered, blaring as loud as ever.");
                        alarmTrigerred = true;
                        electricityTurnedOn = true;
                        Game.Transition<ElectricalRoom>();
                    }break;

                case "off all":
                    {
                        Console.WriteLine("The alarm stops.");
                        alarmTrigerred = false;
                        electricityTurnedOn = false;
                        Game.Transition<ElectricalRoom>();
                    }break;

                case "#":
                    {
                        Console.Write("Enter the 1 or 2 digit number that corresponds to the alarm system: ");
                        response = Convert.ToInt32(Console.ReadLine());
                        {   if (response == alarmBreakerNumber)
                            {
                                Console.WriteLine("'I think this switch did the trick!' The alarm has finally stopped.");
                                alarmTrigerred = false;
                                electricityTurnedOn = true;
                            }
                            else
                            {
                                counter++;
                                Console.WriteLine("That's not the right switch! The alarm hasn't stopped.");
                            }
                        }
                        if (counter > 1 && alarmTrigerred == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Suggestion: You should turn off all the switches for now. If you leave the alarm on for too long, the kidnapper will eventually be notified and return even faster." +
                                "\nTime is of the essence.");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                    }break;

                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<ElectricalRoom>();
                    }break;

                case "circuit breaker":
                    {
                        Console.WriteLine("You look closely and notice the following switches are currently turned off: 4, 8, 11, 15, 16, 23, 42");
                        Game.Transition<ElectricalRoom>();
                    }break;
                    
                default:
                    {
                        Console.WriteLine("Invalid command.");
                    }break;                 
            }
        }
    }
}
