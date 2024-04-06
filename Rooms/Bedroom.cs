using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        internal static bool goneDownstairs = false;
        internal override string CreateDescription()
        {
            if (!goneDownstairs)
            {
                return
@"You are in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
";
            }
            else
            {
                return
@"You're back in the bedroom.
The [door] in front of you leads to the [living room].
The private [bathroom] is to your left.
From the closet, you see the [attic].
Maybe you should look around for tools, you might find a useful [item]!";
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
                        Game.Transition<LivingRoom>();
                        goneDownstairs = true; //
                        //Game.Finish(); //commented this out and made it so that the game only ends after you enter the living room and enter the input to end game.
                    }break;
                case "item":
                    {
                        if (!goneDownstairs)
                        {
                            Console.WriteLine("Nothing useful to you in this room, for the moment...");
                        }
                        else
                        {
                            Console.WriteLine("It's pretty dark downstairs, this flashlight might come in handy!");                           
                            //Game.AddInventory("flashlight");
                        }
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
