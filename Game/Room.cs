using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Room : IRoom
    {

        public string Name { get; set; }
        public string Description { get; set; }

        // public string Action {get; set;}

        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
        
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            // Action = action;

            Items = new List<Item>();
        }


        public void Door(string direction, Room room)
        {
            Exits.Add(direction, room);
        }
        public void UseItem(Item item)
        {
            
        }

        // public void UseItem(Item item)
        // {
        //     throw new NotImplementedException();
        // }
    }
}