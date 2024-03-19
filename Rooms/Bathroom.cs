using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {
        int counter = 0;

        internal override string CreateDescription() =>
@"In your bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your depressed face.
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    Console.WriteLine("You relax in the bath.");
                    counter++;
                    break;
                case "mirror":
                    if (counter >= 1)
                    {
                        Console.WriteLine("You see the numbers 6969 written on the fog on your mirror.");
                    }
                    else
                    {
                        Console.WriteLine("You can't seem to make out the numbers written on the fog on your mirror. (try using the bath to reveal the foggy digits");
                    }                  
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
