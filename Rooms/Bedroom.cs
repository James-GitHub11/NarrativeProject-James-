using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You are in your bedroom.
The [door] in front of you leads to your [living room].
Your private [bathroom] is to your left.
From your closet, you see the [attic].
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
                        Console.WriteLine("You can't enter the living room right now... the door is locked!");
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
                        //Game.Finish(); //commented this out and made it so that the game only ends after you enter the living room and enter the input to end game.
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
