using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        //Lines 13-18 are new
        List<string> inventory = new List<string>();
        string[] collectableItem = { "key", "flashlight", "stealth cloak", "phone" };
        int n;
        static bool flashlightInInventory = false;
        static bool cloakInInventory = false;
        static bool phoneInInventory = false;
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
        internal void AddInventory(string[] collectableItem)
        {
            //int n;
            inventory.Add(collectableItem[n]);
        }
        internal void CheckInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty... Try collecting items/tools to help in the game");
            }
            else
            {
                foreach (var collectableItem in inventory)
                {
                    Console.Write("Here is your current item inventory: ");
                    Console.WriteLine($"{collectableItem}");
                }
            }
        }
    }
}
