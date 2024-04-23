using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        internal static bool goneDownstairs = false;
        internal static bool flashlightAvailable = false;
        internal static bool isFlashLightInventoried = false;
        internal static bool doorReadyToOpen = false;
        internal static bool isShirtInventoried = false;
        internal static bool shirtUsed = false;
        //public Game game = null;
        internal override string CreateDescription()
        {
//            if (goneDownstairs == false)
//            {
//                return
//@"You are in the bedroom.
//The [door] in front of you leads to the [living room].
//The private [bathroom] is to your left.
//From the closet, you see the [attic].
//";
//            }
            if (LivingRoom.isPlayerBleedingOut == true && isShirtInventoried == true && shirtUsed == false)
            {
                return
@"You are in the bedroom.
The [door] leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].

You also can either:
1) Put the [shirt on]?
2) Try to [wrap] the shirt around your wound?";
            }

            if (doorReadyToOpen == true && goneDownstairs == false)
            {
                return
@"Try the [key] you found.";
            }
            if (goneDownstairs == true && flashlightAvailable == false)
            {
                return
@"You're in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
Maybe you should [search] around for tools, you might find a useful item!";
            }
            if (goneDownstairs == true && flashlightAvailable == true && isFlashLightInventoried == false)
            {
                return
@"You're in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
Pick up the [flashlight] and add it to your inventory";
            }
            if (LivingRoom.isPlayerBleedingOut == true && shirtUsed == true)
            {
                return
@"You're in the bedroom.
The main bedroom [door] leads to the [living room].
The private [bathroom] is to the left of the bed.
From the closet, you see the [attic].
There's nothing on the bed anymore (since you took the shirt).
(You've gained health from the warmth of the shirt, but you still need to wrap your wounds).";
            }
            if (LivingRoom.isPlayerBleedingOut == true && goneDownstairs == true && isFlashLightInventoried == true)
            {
                return
@"You're in the bedroom.
The main bedroom [door] leads to the [living room].
The private [bathroom] is to the left of the bed.
From the closet, you see the [attic].
On the bed, there's a plain white [t-shirt]";
            }

            if (goneDownstairs == true && flashlightAvailable == true && isFlashLightInventoried == true)
            {
                return
@"You're in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
(There are currently no items of use in this room).";
            }
            else
            {
                    return
@"You are in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
";
            }
        }
        
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bathroom":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;

                case "living room":
                    {
                        Console.WriteLine("To enter the living room, try the door...");
                    }break;

                case "door":
                    if (AtticRoom.isKeyCollected == true && goneDownstairs == false)
                    {
                        Console.WriteLine("'It looks like a there's a keyslot on this door.'");
                        doorReadyToOpen = true;
                        Game.Transition<Bedroom>();
                    }
                    if (goneDownstairs == true)
                    {
                        Game.Transition<LivingRoom>();
                    }
                    else if (AtticRoom.isKeyCollected == false)
                    {
                        Console.WriteLine("The door is locked.");
                        Game.Transition<Bedroom>();
                    }
                    break;
                case "key":
                    {
                        if (ElectricalRoom.electricityTurnedOn == false && AtticRoom.isKeyCollected == true)
                        {
                            Console.WriteLine("The key fits. You walk down a dark candle-lit hallway.\nWith your eyes still adjusting to the dark, you barely manage to locate the stairs leading to the living room.");
                            goneDownstairs = true;
                            Game.Transition<LivingRoom>();
                        }
                        if (ElectricalRoom.electricityTurnedOn == true && AtticRoom.isKeyCollected == true)
                        {
                            Console.WriteLine("The key fits. You walk through the creepy hallway, with its lights flickering, taking the stairs down to the living room.");
                            Game.Transition<LivingRoom>();
                        }
                        else if (AtticRoom.isKeyCollected == false)
                        {
                            Console.WriteLine("Invalid command.");
                            Game.Transition<Bedroom>();
                        }
                    }break;

                case "search":
                    {
                        if (!goneDownstairs)
                        {
                            Console.WriteLine("Nothing useful to you in this room, for the moment...");
                            Game.Transition<Bedroom>();
                        }
                        else
                        {
                            Console.WriteLine("It's pretty dark downstairs, this flashlight might come in handy!"); //this will reveal the item, but you haven't inventoried it yet.
                            //game.AddInventory(choice);
                            flashlightAvailable = true; //bool to notify when the flashlight has been found 
                            Game.Transition<Bedroom>(); //when found, the game will return to the bedroom (but you'll have a new input option for "flashlight", when you type that, it will add to inventory.
                        }
                    }break;

                case "flashlight":
                    {
                        Game.AddInventory(choice); //once you discover the flashlight, this case option will appear in the altered roomDescription (type "Flashlight" as your "choice" and it will add to inventory.
                        isFlashLightInventoried = true;
                        //flashlightAvailable = false;
                        Game.Transition<Bedroom>();
                    }
                    break;

                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<Bedroom>();
                    }break;
                    
                case "attic":
                    {
                        Console.WriteLine("You go up and enter the attic.");
                        Game.Transition<AtticRoom>();                 
                    }break;

                case "t-shirt":
                    {
                        Console.WriteLine("This shirt seems clean enough.");
                        Game.AddInventory(choice);
                        isShirtInventoried = true;
                        Game.Transition<Bedroom>();
                        //LivingRoom.isPlayerBleedingOut = false;
                    }break;

                case "wrap":
                    {
                        Console.WriteLine("You choose to wrap your wound with the shirt, and have sucessfully stopped the bleeding!");
                        LivingRoom.isPlayerBleedingOut = false;
                        shirtUsed = true;
                        Game.Transition<Bedroom>();
                    }break;

                case "shirt on":
                    {
                        Console.Write("You choose to put the t-shirt on. You feel warmer");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" (+100HP)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nYou're still bleeding out, however. Keep searching for bandages!");
                        shirtUsed = true;
                        Game.hp += 100;
                        Game.Transition<Bedroom>();
                    }break;

                default:
                    {
                        Console.WriteLine("Invalid command.");
                    }break;     
            }
        }
    }
}
