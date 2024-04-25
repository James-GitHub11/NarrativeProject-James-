using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class GarageRoom : Room
    {
        internal static bool isGarageDoorOpen = false;
        internal static bool isPlayerInCar = false;
        internal override string CreateDescription()
        {
            if (Kitchen.isGarageRemoteInventoried == true && isPlayerInCar == true)
            {
                return
@"You're sitting in the car, inside the garage.

What's your next move?
1) Get [out] of the car?
2) Click the button on the unknown [remote]?
3) Try to [drive] straight through the garage door?";
            }

            if (Kitchen.isGarageRemoteInventoried == false && isPlayerInCar == true)
            {
                return
@"You're sitting in the car, inside the garage.

What's your next move?
1) Get [out] of the car?
2) Try to [drive] straight through the garage door?";
            }

            if (Kitchen.isGarageRemoteInventoried == true)
            {
                return
@"You're in the garage room and you see an old car.
Now you're more hopeful than ever of your odds of escape.

What's your next move?
1) Try opening the [car] doors?
2) Try opening the [garage door]
3) Return to the [kitchen]?";
            }
            else
            {
                return
@"You're in the garage room and you see an old car.
Now you're more hopeful than ever of your odds of escape.

What's your next move?
1) Try opening the [car] doors?
2) Try opening the [garage door]
3) Return to the [kitchen]?";
            }  
            
            
//            else
//            {
//                return
//@"";
//            }
            
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "car":
                    {
                        if (Kitchen.isCarKeysInventoried == false)
                        {
                            Console.WriteLine("The car doors are locked. You'll have to find the keys first.");
                            Game.Transition<GarageRoom>();
                        }
                        if (Kitchen.isCarKeysInventoried == true && isGarageDoorOpen == false)
                        {
                            Console.WriteLine("You get in the car and start the engine. However, the garage door is still closed.");
                            isPlayerInCar = true;
                            Game.Transition<GarageRoom>();
                        }
                        if (Kitchen.isCarKeysInventoried == true && isGarageDoorOpen == true)
                        {
                            Console.WriteLine("You get in the car, start the engine and drive off.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("CONGRATULATIONS! You've escaped alive and succesfully completed the game!");
                            Game.Finish();
                        }
                    }break;

                case "drive":
                    {
                        Console.WriteLine("You attempt to go straight through the garage door, but you were not successful.");
                        Console.WriteLine("GAME OVER! (The car crashes into the door and you go unconcious. You can't gain enough speed to break the door.");
                        Game.Finish();
                    }break;

                case "out":
                    {
                        Console.WriteLine("You step out of the vehicle, into the garage.");
                        isPlayerInCar = false;
                        Game.Transition<GarageRoom>();
                    }break;
                case "remote":
                    {
                        if (Kitchen.isGarageRemoteInventoried == true)
                        {
                            Console.WriteLine("You click the button on the remote and the garage door opens.");
                        }
                        
                        isGarageDoorOpen = true;
                        Game.Transition<GarageRoom>();
                    }break;

                case "garage door":
                    {
                        Console.WriteLine("You grab the handle, and put all your strength into lifting the door but it won't budge...");
                        Console.WriteLine("'There must be another way to open it. Maybe there's a switch?'");
                        Game.Transition<GarageRoom>();
                    }break;

                case "kitchen":
                    {
                        Game.Transition<Kitchen>();
                    }break;
            }
        }
    }
}
