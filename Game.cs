using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    public enum CollectableItems
    {
        Key,
        Flashlight,
        StealthCloak,
        Phone
    }
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        //Lines 13-18 are new
        public static List<CollectableItems> inventory = new List<CollectableItems>();
        //static List<string> collectableItems = new List<string> { "key", "flashlight", "stealth cloak", "phone" };
        public int n;
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
        public static void AddInventory(string choice)
        {
            //int n
            //string[] collectableItem = { "key", "flashlight", "stealth cloak", "phone" };
            //inventory.Add(collectableItem[n]);
            if (choice == "Flashlight")
            {
                inventory.Add(CollectableItems.Flashlight);
            }
            if (choice == "Key")
            {
                inventory.Add(CollectableItems.Key);
            }
            if (choice == "StealthCloak")
            {
                inventory.Add(CollectableItems.StealthCloak);
            }
            if (choice == "Phone")
            {
                inventory.Add(CollectableItems.Phone);
            }
        }
        public static void CheckInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty... Try collecting items/tools to help in the game");
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
    }
}
