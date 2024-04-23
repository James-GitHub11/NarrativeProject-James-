using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal static bool isGarageDiscovered = false;
        internal static bool isCounterInspected = false;
        internal static bool isGarageRemoteInventoried = false;
        internal static bool isCarKeysInventoried = false;
        internal override string CreateDescription()
        {
            if (isCounterInspected == true && isCarKeysInventoried == false && isGarageRemoteInventoried == false)
            {
                return
@"In the kitchen, you can hear the storm raging outside.
On the kitchen counter, you notice a fruit bowl, with a set of keys and some sort of remote.

What's your move?
1) Enter the side [door]?
2) Pick up the [car keys]?
3) Pick up the [remote]?";
            }

            if (isCounterInspected == true && isCarKeysInventoried == true && isGarageRemoteInventoried == false)
            {
                return
@"In the kitchen, you can hear the storm raging outside.
On the kitchen counter, there's a fruit bowl, which still has some sort of remote in it.

What's your move?
1) Enter the side [door]?
2) Pick up the [remote]?";
            }

            if (isCounterInspected == true && isCarKeysInventoried == false && isGarageRemoteInventoried == true)
            {
                return
@"In the kitchen, you can hear the storm raging outside.
On the kitchen counter, there's a fruit bowl, which still has a set of car keys in it.

What's your move?
1) Enter the side [door]?
2) Pick up the [car keys]?";
            }
            if (isCarKeysInventoried == true && isGarageRemoteInventoried == true && isGarageDiscovered == false)
            {
                return
@"You're in the kitchen. You've inspected the area and found a set of car keys and some sort of remote...
'Hopefully he left a car here. If I could just find my way out of this house, maybe I'll get lucky.'

What's your move?
1) Check the [window]
2) Check what's behind the [door]?";
            }

            if (isCarKeysInventoried == true && isGarageRemoteInventoried == true && isGarageDiscovered == true)
            {
                return
@"You're in the kitchen. You've got a set car keys and some sort of remote...

What's your move?
1) Check the [window]?
2) Go to the [garage]?";
            }

            if (isGarageDiscovered == false)
            {
                return
@"You're in the kitchen now. You can hear the storm raging outside.
You glance around and notice a [window] that's slightly cracked open,
There's another [door] leading to unkown room.

What's your move?
1) Escape through the [window]?
2) Check out what's behind the [door]?
3) Inspect the kitchen [counter] for anything useful?";
            }

            if (isGarageDiscovered == true)
            {
                return
@"You're in the kitchen. You can hear the storm raging outside.
You glance around and notice a [window] that's slightly cracked open,
There's another [door] leading to the [garage room].

What's your move?
1) Escape through the [window]?
2) Check out what's behind the [door]?
3) Inspect the kitchen [counter] for anything useful?";
            }
            else
            {
                return
@"";
            }
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "door":
                    {
                        isGarageDiscovered = true;
                        Game.Transition<GarageRoom>();
                    }
                    break;

                case "garage":
                    {
                        if (isCarKeysInventoried == true)
                        {
                            Console.WriteLine("You enter the garage and notice that the car keys match the vehicle parked inside.");
                        }
                        if (isCarKeysInventoried == false)
                        {
                            Console.WriteLine("You enter the garage.");
                            Game.Transition<GarageRoom>();
                        }
                        
                    }break;

                case "remote":
                    {
                        Game.AddInventory(choice);
                        isGarageRemoteInventoried = true;
                        Game.Transition<Kitchen>();
                    }break;

                case "car keys":
                    {
                        Game.AddInventory(choice);
                        isCarKeysInventoried = true;
                        Game.Transition<Kitchen>();
                    }break;

                case "window":
                    {
                        Console.WriteLine("You try prying the window open, but it barely budges and the wind keeps forcing it shut.");
                        Console.WriteLine("'Walking out of here safely is probably not an option... but I might not have any other choice.");
                    }break;

                case "counter":
                    {
                        Console.WriteLine("There's envelopes and newspapers scattered all over the counter. You go ahead and clear all the mess.");
                        //Console.WriteLine("You notice there's a fruit bowl on the counter with a set of keys and some sort of remote");
                        isCounterInspected = true;
                    }break;
            }
        }
    }
    
}
