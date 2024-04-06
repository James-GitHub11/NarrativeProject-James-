using NarrativeProject.Rooms;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NarrativeProject
{
    [Serializable]
    public class SaveData
    {
        public int numberToSave;
        public string stringToSave;
    }


    internal class Program
    {
        static SaveData saveData;
        static void Main(string[] args)
        {
            const string SaveFile = "Save.txt";
            if (!File.Exists(SaveFile))
            {
                File.CreateText(SaveFile);
            }

            var game = new Game();
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new AtticRoom());
            game.Add(new LivingRoom());
            game.Add(new FurnaceRoom());

            while (!game.IsGameOver())
            {
                Console.WriteLine("--");
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
