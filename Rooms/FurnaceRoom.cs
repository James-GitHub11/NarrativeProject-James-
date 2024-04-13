using System;

namespace NarrativeProject.Rooms
{
    internal class FurnaceRoom : Room
    {
        internal static bool isFurnaceFixed = false;
        internal override string CreateDescription()
        {
            if (LivingRoom.electricityTurnedOn == true && isFurnaceFixed == false)
            {
                return
@"In the furnace room, there are lots of machinery and wiring all over.
You notice two wires, a [black wire] and a [red wire], that are both disconnected from the furnace.
What's your next move?
1) Return back to the [living room]?
2) Try plugging the [black wire] into the furnace?
3) Try plugging the [red wire] into the furnace?";
            }
            if (LivingRoom.electricityTurnedOn == true && isFurnaceFixed == true)
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
3) Try plugging the [red wire] into the furnace?";
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
                        Game.Transition<LivingRoom>();
                    }break;
                case "red wire":
                    {
                        if (LivingRoom.electricityTurnedOn == false)
                        {
                            Console.WriteLine("Darn. I forgot the power is out on this floor. This won't work");
                            Game.Transition<FurnaceRoom>();
                        }
                        else if (LivingRoom.electricityTurnedOn == true)
                        {
                            Console.WriteLine("You plug in the red wire and... it works! The furnace is finally on. Maybe I should check to see if it's working in the living room.");
                            isFurnaceFixed = true;
                            Game.Transition<FurnaceRoom>();
                        }
                    }break;
            }
        }
    }
}
