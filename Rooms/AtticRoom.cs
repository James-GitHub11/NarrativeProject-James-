using System;

namespace NarrativeProject.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected = false;
        internal static bool isKeyDiscovered = false;

        internal override string CreateDescription()
        {
            if (isKeyDiscovered == true && isKeyCollected == false)
            {
                return
@"In the attic, it's dark and cold.
There's an open chest on the floor with a key inside.

What's your move?
1) Take the [key]?
2) Return to the [bedroom]?";
            }
            if (isKeyCollected == true)
            {
                return
@"You're standing in the old dusty attic.
The open chest lays empty on the ground.
You look around one more time, but there doesn't seem to be anything else of use here.

Next move:
1) Return to the [bedroom]";
            }
            else
            {
                return
@"In the attic, it's dark and cold.
A chest is locked with a 4-digit code [????].
You can return to the [bedroom].
";
            }
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bedroom":
                    Console.WriteLine("You return to the bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "6969":
                    Console.WriteLine("The chest opens, revealing a mysterious key.");
                    Game.Transition<AtticRoom>();
                    isKeyDiscovered = true;
                    break;
                case "key":
                    {
                        Game.AddInventory(choice);
                        isKeyCollected = true;
                        Game.Transition<AtticRoom>();
                    }
                    break;

                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<AtticRoom>();
                    }break;
                    
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
