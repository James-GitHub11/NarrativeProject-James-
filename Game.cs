using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace NarrativeProject
{
    public enum CollectableItems
    {
        Key,
        Flashlight,
        Bandages,
        Phone
    }
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        public static List<CollectableItems> inventory = new List<CollectableItems>();
        public static int hp = 1000;
        //public int n;
        //static bool flashlightInInventory = false;
        //static bool cloakInInventory = false;
        //static bool phoneInInventory = false;

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
        //Additional Work (April 02, 2024)
        public static void AddInventory(string choice)
        {
            //int n
            //string[] collectableItem = { "key", "flashlight", "stealth cloak", "phone" };
            //inventory.Add(collectableItem[n]);
            if (choice == "flashlight")
            {
                inventory.Add(CollectableItems.Flashlight);
            }
            if (choice == "key")
            {
                inventory.Add(CollectableItems.Key);
            }
            if (choice == "bandages")
            {
                inventory.Add(CollectableItems.Bandages);
            }
            if (choice == "phone")
            {
                inventory.Add(CollectableItems.Phone);
            }
        }
        public static void CheckInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty (Try collecting items/tools to help in the game)");
            }
            else
            {
                foreach (var CollectableItems in inventory)
                {
                    Console.Write("Here is your current item inventory: ");
                    Console.WriteLine($"{CollectableItems}");
                }
            }
        }
        //public static void AlarmTimerDamage(int hp, game.alarmTimer)
        //{
        //    if (ElectricalRoom.alarmTrigerred == false)
        //    {
        //        Console.WriteLine("");
        //    }
        //    if (ElectricalRoom.alarmTrigerred == true)
        //    {
        //        alarmTimer
        //        //hp -= alarmTimer.Elapsed.Seconds
        //    }

        //}
    }
}
