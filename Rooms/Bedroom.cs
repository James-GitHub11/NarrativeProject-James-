using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        internal static bool goneDownstairs = false;
        internal override string CreateDescription() =>
@"You are in your bedroom.
The [door] in front of you leads to your [living room].
Your private [bathroom] is to your left.
From your closet, you see the [attic].
Don't forget to look around for tools, you might find a useful [item]!
";

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
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
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
                            
                            //Game.AddInventory(collectableItem);
                        }
                    }break;
                    
                case "attic":
                    {
                        Console.WriteLine("You go up and enter your attic.");
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
