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
            if (goneDownstairs == true && flashlightAvailable == true && isFlashLightInventoried == true)
            {
                return
@"You're in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
(There are no more items to find here.)";
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

                default:
                    {
                        Console.WriteLine("Invalid command.");
                    }break;     
            }
        }
    }
}
