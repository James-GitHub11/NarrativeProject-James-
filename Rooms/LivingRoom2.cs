using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom2 : Room
    {
        internal static bool isSlidingDoorOpened = false;
        internal static bool isPhoneRinging = false;
        internal static bool isPhoneAnswered = false;
        internal static bool isEscapeTimerActivated = false;
        internal override string CreateDescription()
        {
            if (isPhoneRinging == true && isPhoneAnswered == false)
            {
                return
@"Mounted on the wall in the hallway, a cordless landline phone is ringing non-stop.
The call says 'No caller ID'.
At the end of this hallway, you can see the kitchen.

What's your next move?
1) Pick up the [phone]?
2) Keep going to the [kitchen]?";
            }
            if (isPhoneRinging == true && isPhoneAnswered == true)
            {
                return
@"You hang up the phone and contemplate for a moment...
'Did the head injury make me lose my mind? Am I just being paranoid about all of this?'
'The notes he left and his words on the phone all seemed genuine and reasurring...'
'But, based on everything I've experienced in this house, my instincts are screaming RUN!'
'Am I being too quick to judge this person?'

You have two choices:
1) Put your faith in humanity, and [wait] to meet/thank him before leaving?
2) Listen to your instincts, and continue your [escape]?";
            }
            if (isSlidingDoorOpened == true)
            {
                return
@"Game Level 2: ESCAPE
-------------------------
Standing in front of the opened sliding door, you can see there's an [extention] to the house.
Behind you is the rest of the [living room], and the other small hallway that leads to the [front door].

Next move:
1) Try the [front door]?
2) Walk through the sliding door into the [extension]?
3) Return to the main [living room] area?";
            }
            else
            {
                return
@"Game Level 2: ESCAPE
-------------------------
You're standing in the living room with the power on.
Finally having warmth and lighting everywhere, you're fully focused on escape.
You manage to spot a sliding door, painted so that it essentially blends into the walls.

What's your move?
1) Open the [sliding door]?
2) Try the [front door] again?
3) Return to the main [living room] area?";
            }
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "extension":
                    {
                        Console.WriteLine("You walk through the hall towards what appears to be the kitchen, when you hear a phone start to ring...");
                        isPhoneRinging = true;
                        Game.Transition<LivingRoom2>();
                    }break;

                case "wait":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("GAME OVER!\n(It's not always a bad thing to have faith in humanity, but in adrenaline-fueled moments like this, you're instincts rarely lie.)");
                        Console.ForegroundColor = ConsoleColor.White;
                        Game.Finish();
                    }break;

                case "escape":
                    {
                        Console.WriteLine("You go with your gut instincts, ignoring the man's request for your to remain put.");
                        Console.WriteLine("You put the phone back on the wallmount, and heads into the kitchen.");
                        isEscapeTimerActivated = true;
                        Game.Transition<Kitchen>();
                    }break;

                case "phone":
                    {
                        Console.WriteLine("You answer the phone and wait for a response...");
                        Console.WriteLine("'I noticed the alarm was set off. I hope you're not trying to leave...'");
                        Console.WriteLine("'Nobody should go out in this storm, you should stay till it passes.'");
                        Console.WriteLine("'I am on my way back with some painkillers for your head injury, and some other supplies to last the storm.'");
                        isPhoneAnswered = true;
                        Game.Transition<LivingRoom2>();
                    }break;

                case "front door":
                    {
                        Console.WriteLine("You turn the lock and try opening the door, but it won't budge...");
                        Console.WriteLine("'No questions about it now, whoever lives here is trying to keep me locked in... I gotta get out.'");
                        Game.Transition<LivingRoom2>();
                    }break;

                case "sliding door":
                    {
                        isSlidingDoorOpened = true;
                        Console.WriteLine("You slide open the door, and notice there's more hallway ahead, leading to an extention of the house");
                        Game.Transition<LivingRoom2>();
                    }break;
                case "living room":
                    {
                        Game.Transition<LivingRoom>();
                    }break;
            }
        }
    }
}
