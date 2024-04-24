using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    internal class StoryContext1 : Story
    {      
        internal override void CreateStoryContext(string storyChoice)
        {
            switch (Game.storyChoice)
            {
                case "1":
                    {
                        Console.WriteLine("Game type: Narrative Adventure / Escape Room / Thriller / Mystery");
                        Console.WriteLine("Context: ");
                        Console.WriteLine("You wake up in the middle of the night, with a pounding headache and severe chills.");
                        Console.WriteLine("You look around confused... this is not your bed, not even your home, and you're not sure how you got there.");
                        Console.WriteLine("The last memory you can recall is you leaving the bar, trying to run home through the rain.");
                        Console.WriteLine("The cold, darkness and your confusion/curiosity give you enough energy to get up and figure out what happened.");
                        Console.WriteLine("Press any button to begin the game...");
                        Console.ReadLine();
                    }break;

                case "2":
                    {

                    }break;


            }
            
        }
    }
}
