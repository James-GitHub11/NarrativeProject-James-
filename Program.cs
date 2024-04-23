using NarrativeProject.Rooms;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

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
            game.Add(new LivingRoom2());
            game.Add(new Kitchen());
            game.Add(new GarageRoom());
            Stopwatch alarmTimer = new Stopwatch();
            bool isAlarmTimerStarted = false;
            Stopwatch bleedingOutTimer = new Stopwatch();
            bool isBleedingOutTimerStarted = false;
            Stopwatch MouseTrapTimer = new Stopwatch();
            bool isMouseTrapTimerStarted = false;
            Stopwatch endGameTimer = new Stopwatch();
            bool isEndTimerRunning = false;
            int endTimerDuration = 10;
            int minutesLeftToEscape = endTimerDuration - (int)endGameTimer.Elapsed.TotalMinutes;
            int secondsLeftToEscape = 60 - (int)endGameTimer.Elapsed.Seconds;
            //stopwatch.Start();
            if (Game.hp <= 0)
            {
                Console.WriteLine("GAME OVER! (You're HP hit zero)");
                Game.Finish();
            }
            
            while (!game.IsGameOver())
            {
                if (LivingRoom2.isEscapeTimerActivated == true && isEndTimerRunning == false)
                {
                endGameTimer.Start();
                isEndTimerRunning = true;
                }              
                if (LivingRoom2.isEscapeTimerActivated == true && isEndTimerRunning == true && (int)endGameTimer.Elapsed.TotalMinutes <= endTimerDuration)
                {
                    
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"Time Remaining: {endTimerDuration - (int)endGameTimer.Elapsed.TotalMinutes} minutes and " + $"{60 - (int)endGameTimer.Elapsed.Seconds} seconds.");
                }
                if ((int)endGameTimer.Elapsed.TotalMinutes >= endTimerDuration)
                {
                    Console.WriteLine("GAME OVER! (your time ran out!)");
                    Game.Finish();
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Player HP: {Game.hp}");
                Console.WriteLine("--------------------------------");
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
                if (choice == "off all" || ElectricalRoom.response == 11) //If either of these are inputted, the timer will stop and your HP will stop dropping
                {
                    alarmTimer.Stop();
                    //alarmTimer.Reset();
                    isAlarmTimerStarted = false;
                }
                if (isAlarmTimerStarted == true)
                {
                    Game.hp -= (int)alarmTimer.Elapsed.TotalSeconds; //deducts HP for as long as the home security alarm is left on.
                }

                if (LivingRoom.isPlayerBleedingOut == true && isBleedingOutTimerStarted == false) //if the player steps on a nail, the bleeding out timer begins.
                {
                    bleedingOutTimer.Reset();
                    bleedingOutTimer.Start();
                    isBleedingOutTimerStarted = true;
                }
                
                if (LivingRoom.isPlayerBleedingOut == false && isBleedingOutTimerStarted == true)
                {
                    bleedingOutTimer.Stop();
                    isBleedingOutTimerStarted = false;
                }

                if (isBleedingOutTimerStarted == true) //while bleedingOutTimer is left on, lose HP until they find something to wrap their wounds (using bandages or the t-shirt)
                {
                    Game.hp -= (int)bleedingOutTimer.Elapsed.TotalSeconds;
                }

                if (ElectricalRoom.stuckInMouseTrap == true && isMouseTrapTimerStarted == false)
                {
                    MouseTrapTimer.Reset();
                    MouseTrapTimer.Start();
                    isMouseTrapTimerStarted = true;
                }
                if (ElectricalRoom.stuckInMouseTrap == false && isMouseTrapTimerStarted == true)
                {
                    MouseTrapTimer.Stop();
                    isMouseTrapTimerStarted = false;
                }
                if (isMouseTrapTimerStarted == true)
                {
                    Game.hp -= (int)MouseTrapTimer.Elapsed.TotalSeconds;
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
