using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        internal static bool goneDownstairs = false;
        internal static bool flashlightAvailable = false;
        internal static bool isFlashLightInventoried = false;
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
            if (goneDownstairs == true && flashlightAvailable == false)
            {
                return
@"You're back in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
Maybe you should [search] around for tools, you might find a useful item!";
            }
            if (goneDownstairs == true && flashlightAvailable == true && isFlashLightInventoried == false)
            {
                return
@"You're back in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
Pick up the [flashlight] and add it to your inventory";
            }
            if (goneDownstairs == true && flashlightAvailable == true && isFlashLightInventoried == true)
            {
                return
@"You're back in the bedroom.
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
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and leave the bedroom.");
                        goneDownstairs = true;
                        Game.Transition<LivingRoom>();
                        
                        //Game.Finish(); //commented this out and made it so that the game only ends after you enter the living room and enter the input to end game.
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
