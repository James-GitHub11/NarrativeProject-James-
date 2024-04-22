using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {
        int counter = 0;

        internal override string CreateDescription() =>
@"In the bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your fatigued and slightly bruised face.
You can return to the [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    {
                        Console.WriteLine("You relax in the bath, and regain a bit of your energy.");
                        Game.hp += 100;
                        counter++;
                    } break;
                    
                case "mirror":
                    {
                        if (counter >= 1)
                        {
                            Console.WriteLine("The fog from the bath reveals the numbers '6969', written on the mirror with greasy fingerprints.");
                        }
                        else
                        {
                            Console.WriteLine("You can't seem to make out the numbers written on the fog on the mirror. (try using the bath to reveal the foggy digits");
                        }
                    } break;


                case "bedroom":
                    {
                        Console.WriteLine("You return to the bedroom.");
                        Game.Transition<Bedroom>();
                    } break;

                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<Bathroom>();
                    }
                    break;
                    
                    
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
