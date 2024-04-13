using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal abstract class ElectricRoom : Room
    {
        internal override string CreateDescription()
        {
            return
@"";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "living room":
                    {
                        Game.Transition<LivingRoom>();
                    }break;
            }
        }
    }
}
