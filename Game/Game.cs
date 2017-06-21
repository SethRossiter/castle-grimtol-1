using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public Boolean Playing { get; set; }

        public void Setup()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What a night, nickel beers at the bar! Phew!!! I'll just order a pizza and ZZZZZZZ''''''' ");
            Console.WriteLine("\n");
            CurrentPlayer = new Player();
            Console.WriteLine("\n");
            Help();
        }
        public void Reset()
       {
           Console.Clear();
           Setup();
           CreateRooms();
       }
        public string GetUserInput()
        {
            System.Console.WriteLine("What would you like to do now?");
            string input = Console.ReadLine();
            return input;
        }
        public void Quit()
        {            
           
            Console.WriteLine("Are you sure you want to quit the game?");
            var userChoice = Console.ReadLine();
            if(userChoice.ToLower() == "y" || userChoice.ToLower() == "yes")
            {
             Console.WriteLine("BOOOOOOOOO");
             bool playing = false;
             Console.Clear();
             Environment.Exit(0);
            }              
            else if(userChoice.ToLower() == "n" || userChoice.ToLower() == "no")
            {
             Console.WriteLine("Keep Going!");
             bool playing = true;
            }
        }

        public void Help()
        {
            Console.WriteLine("north, south, east, west - moves your player.  \nl or look will make you look around the current room.  \ni or inventory will show your inventory. \nt or take will take the item from a room. \nq or quit will quit the game.\n r or reset will reset the game.");
        }
         

        public void Look(Room room)
        {
            Console.WriteLine($"{room.Name}:\n{room.Description}:\n{room.Items}");
            for (int i = 0; i < room.Items.Count; i++)
            {
                System.Console.WriteLine($"Items: {room.Items[i].Name}\n");
            }
        }
        public void Take(string itemName)
        {
            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            if(item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                // Console.WriteLine($"{item.Name}:\n{item.Description}");
                Console.WriteLine("Item added to your inventory!");
            }
         
        }

         public void UseItem(string itemName)
        {
           string CarWin = "car";
           string MushroomLose = "mushrooms";
            if(itemName.ToLower() == CarWin)
            {
              Console.ForegroundColor = ConsoleColor.Blue;
              Console.WriteLine("You don't believe it...the keys are in the ignition!!! You fire that puppy up and start down the road...");
              CurrentPlayer.Score += 50;
              Console.WriteLine("WINNER!");
              Console.WriteLine("Wait...I wonder where this road leads? BA BA BUMMMMMMMMMM");
              Console.WriteLine("play again? - y/n");
              string input = Console.ReadLine().ToLower();
              if(input == "y")
              {
                  Reset();
              }
              else if(input == "n")
              {
                Console.Clear();
                Environment.Exit(0);
              }
            }
            if(itemName.ToLower() == MushroomLose)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Man you were hungry! Good thing you found those mushrooms!  Stomach is starting to feel a little weird though!");
                Console.WriteLine("DEAD!!!!!!!!!! SHOULDN'T HAVE EATEN THOSE MUSHROOMS!!!!!");
                Playing = false;
            }

        }

        
        
       public void CreateRooms()
       {
            //ROOM NAME & DESCRIPTION
            Room Woods = new Room("Woods", "...Where the...you're in the woods!!! Is that water you hear to the north?");
            Room River = new Room("River", "Thats water is moving pretty quick...what now!?");
            Room Meadow = new Room("Meadow", "Look at all the flowers! Wait, are those mushrooms?  Man, you are sure hungry...");
            Room DirtRoad = new Room("Dirt Road", "A ROAD. A CAR.");
           
            CreateExits();
            CreateItems();

            void CreateExits()
       {
            //EXITS ROOM IN DIRECTION INTO NEW ROOM
            Woods.Door("north", River);
            River.Door("south", Woods);
            River.Door("north", Meadow);
            Meadow.Door("south", River);
            Meadow.Door("north", DirtRoad);
            DirtRoad.Door("south", Meadow);       
    }

        void CreateItems()
        {
        // ITEM NAME & DESCRIPTION
            Item mushrooms = new Item("mushrooms", "A dark brown morsel");
            Item car = new Item("car", "Looks like a 69' Pinto");           

            //ROOM CONTAINING ITEMS
            Meadow.Items.Add(mushrooms);
            DirtRoad.Items.Add(car);
            
        }
        CurrentRoom = Woods;
       }
    }
}
    
          


//             // ITEM NAME & DESCRIPTION

//             Item Key = new Item("Key", "A beat up Skeleton key");
//             Inventory.Add("key", Key);
//             Item GuardUniform = new Item("Uniform", "A pungent Guard Uniform");
//             Inventory.Add("Uniform", GuardUniform);
//             Item Note = new Item("Note", "Note for the gate Captain");
//             Inventory.Add("Note", Note);
//             Item Vial = new Item("Vial", "Vial full of green liquid");
//             Inventory.Add("Vial", Vial);
//             Item Hammer = new Item("Hammer", "An old BlackSmith hammer");
//             Inventory.Add("Hammer", Hammer);
//             Item BrokenLock = new Item("Broken Lock", "A rusty broken lock");
//             Inventory.Add("BrokenLock", BrokenLock);
//             Item MessengerOvercoat = new Item("Messenger Overcoat", "A messenger overcoat");
//             Inventory.Add("Messenger Overcoat", MessengerOvercoat);

//             //ROOM CONTAINING ITEMS
//             Dungeon.Items.Add("BrokenLock", BrokenLock);//Show to captain
//             barracks.Items.Add("GuardUniform", GuardUniform);//Must wear to keep going in the game
//             barracks.Items.Add("Key", Key);//key for CaptainsQuarters
//             CaptainsQuarters.Items.Add("Vial", Vial);//pour into cup in Council Room
//             CaptainsQuarters.Items.Add("Note", Note);//Give to messenger in squire tower
//             CaptainsQuarters.Items.Add("Key", Key);//key for dungeon
//             GuardRoom.Items.Add("Hammer", Hammer);//break prisoners lock in the dungeon
//             SquireTower.Items.Add("MessengerOvercoat", MessengerOvercoat);//Have to give it to the prisoner

            

        
//     }

  
// }