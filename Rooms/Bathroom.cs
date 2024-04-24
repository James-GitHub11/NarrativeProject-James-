using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {
        int counter = 0;
        internal static bool isCabinetOpened = false;
        internal static int HealthGainedInBath = 100;
        //internal static bool 

        internal override string CreateDescription()
        {
            if (isCabinetOpened == true)
            {
                return
@"In the bathroom, the [bath] is filled with hot water.
The [mirror] is opened and you can see what's inside the [cabinet].
You can also return to the [bedroom].

What's your move?
1) Inspect the [pills]?
2) Take the [med-kit]?
3) Take a [bath]?
4) Return to [bedroom]?";
            }
            if (LivingRoom.isPlayerBleedingOut == true || ElectricalRoom.stuckInMouseTrap == true && isCabinetOpened == false)
            {
                return
@"In the bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your fatigued and slightly bruised face.
As you glance in the mirror, you notice this time around that there's an unlocked [cabinet] behind it.
You can also return to the [bedroom].
";
            }
//            if (LivingRoom.isPlayerBleedingOut == true && isCabinetOpened == true || ElectricalRoom.stuckInMouseTrap == true && isCabinetOpened == true)
//            {
//                return
//@"In the bathroom, the [bath] is filled with hot water.
//The [mirror] is opened and you can see what's inside the [cabinet].
//You can also return to the [bedroom].

//What's your move?
//1) Inspect the [pills]?
//2) Take the [med-kit]?
//3) Take a [bath]?
//";
//            }
            else
            {
                return
@"In the bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your fatigued and slightly bruised face.
You can return to the [bedroom].
";
            }
            
            
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    {
                        //if (isCabinetOpened)
                        if (HealthGainedInBath > 0)
                        {
                            Console.WriteLine($"You relax in the bath, and regain a bit of your energy. (+{HealthGainedInBath}HP)");
                            Game.hp += HealthGainedInBath;
                            HealthGainedInBath -= 25; //each time the bath is used, you'll gain 25 less HP per use. (1st use = 100HP, 2nd = 75HP...)
                        }
                        else
                        {
                            Console.WriteLine("The bath water has gone cold. Any further baths won't affect your current health.");
                        }
                        counter++;
                        Game.Transition<Bathroom>();
                    }break;
                    
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
                        Game.Transition<Bathroom>();
                    }break;

                case "bedroom":
                    {
                        Console.WriteLine("You return to the bedroom.");
                        Game.Transition<Bedroom>();
                    }break;

                case "inventory":
                    {
                        Game.CheckInventory();
                        Game.Transition<Bathroom>();
                    }break;
                    
                case "cabinet":
                    {
                        Console.WriteLine("You open the cabinet and see a few things inside... a medical-kit, some pill bottles, and a single tooth-brush.");
                        isCabinetOpened = true;
                        Game.Transition<Bathroom>();
                    }
                    break;

                case "pills":
                    {
                        Console.WriteLine("You pick up the pill bottles and inspect them. You react in denial: 'OMG... please tell me I'm confusing the medical terms for these...'");
                        Console.WriteLine("'If I remember these names correctly from my pharmacology class.. Olanzapine is used to treat schizophrenia...");
                        Console.WriteLine("'Well, that could potentially explain the home-owner's erratic behavior and lack of proper home maintenance...'");
                        Console.WriteLine("'Wait... ROHYPNOL??? Are these roofies?!? Hell no... I GOTTA OUTTA HERE!");
                        isCabinetOpened = false;
                        Game.Transition<Bathroom>();
                    }break;

                case "med-kit":
                    {
                        if (ElectricalRoom.stuckInMouseTrap == true && LivingRoom.isPlayerBleedingOut == true)
                        {
                            Console.WriteLine("You take the med-kit, using it to bandage your pierced foot and to pry off the trap, and then you disinfect your foot/toe from the rusty objects.");
                            LivingRoom.isPlayerBleedingOut = false;
                            ElectricalRoom.stuckInMouseTrap = false;
                        }
                        if (ElectricalRoom.stuckInMouseTrap == true && LivingRoom.isPlayerBleedingOut == false)
                        {
                            Console.WriteLine("You open the med-kit, using the scissors to pry off the trap, then disinfect and bandage your toes.");
                            ElectricalRoom.stuckInMouseTrap = false;
                        }
                        if (ElectricalRoom.stuckInMouseTrap == false && LivingRoom.isPlayerBleedingOut == true)
                        {
                            Console.WriteLine("You open the med-kit, using it to disinfect and wrap your wounded foot.");
                            LivingRoom.isPlayerBleedingOut = false;
                        }
                        Game.AddInventory(choice);
                        isCabinetOpened = false;
                        Game.Transition<Bathroom>();
                        //ElectricalRoom.stuckInMouseTrap = false;
                    }break;
                default:
                    {
                        Console.WriteLine("Invalid command.");
                        Game.Transition<Bathroom>();
                    }break;
                    
            }
        }
    }
}
