using NarrativeProject.Rooms;
using System;
using System.Diagnostics;
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
        //static Stopwatch stopwatch = new Stopwatch();
        //static int hp = 1000;
        static void Main(string[] args)
        {
            const string SaveFile = "Save.txt";
            if (!File.Exists(SaveFile))
            {
                File.CreateText(SaveFile);
            }
            var game = new Game();
            game.Add(new Bedroom());
            //var bedroom = new Bedroom();
            //bedroom.game = game;
            game.Add(new Bathroom());
            game.Add(new AtticRoom());
            game.Add(new LivingRoom());
            game.Add(new FurnaceRoom());
            game.Add(new ElectricalRoom());
            Stopwatch alarmTimer = new Stopwatch();
            bool isAlarmTimerStarted = false;
            //stopwatch.Start();

            while (!game.IsGameOver())
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Player HP: {Game.hp}");
                Console.WriteLine(game.CurrentRoomDescription);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("HINT: You can also check your [inventory]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------");
                //stopwatch.Elapsed(h{ }, );
                string choice = Console.ReadLine().ToLower() ?? "";
                if (choice == "switches" && isAlarmTimerStarted == false)
                {
                    alarmTimer.Reset();
                    alarmTimer.Start();
                    isAlarmTimerStarted = true;
                }
                if (choice == "off all" || ElectricalRoom.response == 11)
                {
                    alarmTimer.Stop();
                    //alarmTimer.Reset();
                    isAlarmTimerStarted = false;
                }
                if (isAlarmTimerStarted == true)
                {
                    Game.hp -= (int)alarmTimer.Elapsed.TotalSeconds;
                }
                
                Console.Clear();
                game.ReceiveChoice(choice);
                //if (ElectricalRoom.alarmTrigerred == true && ElectricalRoom.isTimerStarted == false)
                //{
                //    alarmTimer.Start();
                //}
                //while (ElectricalRoom.alarmTrigerred == true)
                //{
                //    Game.hp -= alarmTimer.Elapsed.Seconds;
                //}
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
