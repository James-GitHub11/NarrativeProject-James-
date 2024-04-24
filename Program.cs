using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace NarrativeProject
{
    [Serializable]
    public class SaveData
    {
        public int hpToSave;
        public string nameToSave;
        public string roomToSave;
        public int savedHP;
        public string savedName;
        public string savedRoom;
        //public 
        public SaveData(int hpToSave, string nameToSave, string roomToSave)
        {
            hpToSave = savedHP;
            nameToSave = savedName;
            roomToSave = savedRoom;
        }
    }


    internal class Program
    {
        static SaveData saveData;
        //static Stopwatch stopwatch = new Stopwatch();
        //static int hp = 1000;
        static void Main(string[] args)
        {
            const string SaveFile = "GameSave.txt";
            if (!File.Exists(SaveFile))
            {
                File.CreateText(SaveFile);
            }
            var bf = new BinaryFormatter();
            //saveData = new SaveData();
            //saveData = new SaveData(Game.hp, Game.currentRoom);
            //File.WriteAllText(SaveFile, $"Save Data:\nPlayer HP = {Game.hp}\nCurrent Room = {Game.playerCurrentRoom}\nPlayer Inventory = {Game.inventory}");
            //string playerSave = File.ReadAllText(SaveFile);
            //Console.WriteLine(playerSave);
            //Game.GetStoryChoice();
            //Story selectedStory = new StoryContext1(Game.GetStoryChoice);
            //Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|| Mystery/Thriller Escape Room Game ||");
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Context: ");
            Console.WriteLine("You wake up in the middle of the night, with a pounding headache and severe chills.");
            Console.WriteLine("You look around confused... this is not your bed, not even your home, and you're not sure how you got there.");
            Console.WriteLine("The last memory you can recall is you leaving the bar, trying to run home through the rain.");
            Console.WriteLine("The cold, darkness and your confusion/curiosity give you just enough energy to get up and explore.\n");
            Console.WriteLine("----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PRESS ENTER to begin the game...");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
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
            int endTimerDuration = 9;
            int minutesLeftToEscape = endTimerDuration - (int)endGameTimer.Elapsed.TotalMinutes;
            int secondsLeftToEscape = 60 - (int)endGameTimer.Elapsed.Seconds;
            //stopwatch.Start();
            
            
            while (!game.IsGameOver())
            {
                if (Game.hp <= 0)
                {
                    Console.WriteLine("---------------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("GAME OVER! (You're HP hit zero)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("---------------------------------");
                    Game.Finish();
                    continue;
                }
                if (LivingRoom2.isEscapeTimerActivated == true && isEndTimerRunning == false)
                {
                endGameTimer.Start();
                isEndTimerRunning = true;
                }              
                if (LivingRoom2.isEscapeTimerActivated == true && isEndTimerRunning == true && (int)endGameTimer.Elapsed.TotalMinutes <= endTimerDuration)
                {
                    
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Time Remaining: {endTimerDuration - (int)endGameTimer.Elapsed.TotalMinutes} minutes and " + $"{60 - (int)endGameTimer.Elapsed.Seconds} seconds.");
                }
                if ((int)endGameTimer.Elapsed.TotalMinutes >= endTimerDuration)
                {
                    Console.WriteLine("GAME OVER! (your time ran out!)");
                    Game.Finish();
                }
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Player HP: {Game.hp}");
                Console.WriteLine("---------------------------------");
                Console.WriteLine(game.CurrentRoomDescription);
                
                Console.WriteLine("---------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("|  [save]  |  [load]  |  [exit]  |");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------");
                //stopwatch.Elapsed(h{ }, );
                string choice = Console.ReadLine().ToLower() ?? "";
                if (choice == "save")
                {
                    //saveData = new SaveData();
                    game.CheckTransition();
                    //savedRoom = Convert.ToString(Game.currentRoom);
                    goto Jump1; 
                }
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
            //end of game loop
            Jump1:

            //if (Game.playerCurrentRoom == "wait")
            //{
            //    Game.playerCurrentRoom = "extension";
            //}
            //if (Game.playerCurrentRoom == "drive")
            //{
            //    Game.playerCurrentRoom = "garage";
            //}
            //if (Game.playerCurrentRoom == "car")
            //{
            //    Game.playerCurrentRoom = "GarageRoom";
            //}
                //List<CollectibleItems> savedInventory = new List<CollectibleItems>();
                //foreach (var CollectibleItems in Game.inventory)
                //{
                //    savedInventory.Add(CollectibleItems);
                //}



            //File.WriteAllText(SaveFile, $"Save Data:\nPlayer HP = {Game.hp}\nCurrent Room = {Game.playerCurrentRoom}\n");//Player Inventory = {Game.inventory}");
            //string playerSave = File.ReadAllText(SaveFile);
            Console.WriteLine(saveData.nameToSave);
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
