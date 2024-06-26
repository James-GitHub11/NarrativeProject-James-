﻿using System;

namespace NarrativeProject.Rooms
{
    internal class FurnaceRoom : Room
    {
        internal static bool isFurnaceFixed = false;
        internal override string CreateDescription()
        {
            if (ElectricalRoom.electricityTurnedOn == true && isFurnaceFixed == false)
            {
                return
@"In the furnace room, there are lots of machinery and wiring all over.
You notice two wires, a [black wire] and a [red wire], that are both disconnected from the furnace.

What's your next move?
1) Return back to the [living room]?
2) Try plugging the [black wire] into the furnace?
3) Try plugging the [red wire] into the furnace?";
            }
            if (ElectricalRoom.electricityTurnedOn == true && isFurnaceFixed == true)
            {
                return
@"You're in the furnace room. The dripping has finally stopped. 
Everything seems to be working properly in here.
There's nothing left to do in here.

Return to the [living room].";
            }
            else
            {
                return
@"You're in the furnace room. There's a loud dripping noise. The furnace seems to be broken.
You barely spot two hanging wires, a [black wire] and a [red wire], that are both disconnected from the furnace.

What's your next move?
1) Return back to the [living room]?
2) Try plugging the [black wire] into the furnace?
3) Try plugging the [red wire] into the furnace?
4) Try plugging the [green wire] into the furnace?";
            }
        }
        
//Note: i plan to add a notebook image that the person can interact with, when they pick up the note on the table, it will say "always bet on red" with a drawing of a roulette table.
//This will be the hint that the user needs to use to make the right choice, if not its 50/50
//If they select the black wire, it will shock them with electricity and they'll lose HP.
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "living room":
                    {
                        if (ElectricalRoom.alarmTrigerred == false && ElectricalRoom.electricityTurnedOn == true && isFurnaceFixed == true)
                        {
                            Console.WriteLine("Checkpoint achieved!\nThe room seems to be getting warmer now and you're no longer shivering.\nWith the cold no longer a distraction, running electricity, and the alarm turned off, you can finally focus all your efforts on escape!");
                            LivingRoom.isCheckPointAchieved = true;
                            Game.Transition<LivingRoom2>();
                        }
                        else
                        {
                            Game.Transition<LivingRoom>();
                        }
                            
                    }break;
                case "red wire":
                    {
                        if (ElectricalRoom.electricityTurnedOn == false)
                        {
                            Console.WriteLine("Darn. I forgot the power is out on this floor. This won't work");
                            Game.Transition<FurnaceRoom>();
                        }
                        else if (ElectricalRoom.electricityTurnedOn == true)
                        {
                            Console.WriteLine("You plug in the red wire and... it works! The furnace is finally on.");
                            isFurnaceFixed = true;
                            Game.Transition<FurnaceRoom>();
                        }
                    }break;
                
                case "black wire":
                    {
                        if (ElectricalRoom.electricityTurnedOn == false)
                        {
                            Console.WriteLine("'Darn. I forgot the power is out on this floor. This won't work!'");
                            Game.Transition<FurnaceRoom>();
                        }
                        else if (ElectricalRoom.electricityTurnedOn == true)
                        {
                            Console.WriteLine("You try the black one, but it's the wrong wire.\nAn electric shock hits your body, with the pain paralyzing you for a minute.\nYou get back up, in disbelief of what just happened. 'Is this homeowner rigging traps? Or just a sociopath with no concern for safety?!'");
                            Game.hp -= 100;
                            //Will implement a loss of health points here when the user chooses the black wire and get's shocked.
                            Game.Transition<FurnaceRoom>();
                        }                 
                    }break;

                case "green wire":
                    {
                        if (ElectricalRoom.electricityTurnedOn == false)
                        {
                            Console.WriteLine("'Darn. I forgot the power is out on this floor. This won't work!'");
                            Game.Transition<FurnaceRoom>();
                        }
                        else if (ElectricalRoom.electricityTurnedOn == true)
                        {
                            Console.WriteLine("You try the green one, but it's the wrong wire.\nAn electric shock hits your body, with the pain paralyzing you for a minute.\nYou get back up, in disbelief of what just happened. 'Is this homeowner rigging traps? Or just a sociopath with no concern for safety?!'");
                            Game.hp -= 100;
                            //Will implement a loss of health points here when the user chooses the black wire and get's shocked.
                            Game.Transition<FurnaceRoom>();
                        }
                    }
                    break;
                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<FurnaceRoom>();
                    }break;     
            }
        }
    }
}
