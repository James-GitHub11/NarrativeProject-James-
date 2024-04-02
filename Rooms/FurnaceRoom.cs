using System;

namespace NarrativeProject.Rooms
{
    internal class FurnaceRoom : Room
    {
        internal override string CreateDescription() =>
@"In the furnace room, there are lots of wiring and machinery.
Two codes are written down  with the code [].
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            //switch (choice)
            //{ 
            //    case ""
            //}
        }
    }
}
