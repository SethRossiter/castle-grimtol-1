using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        public string CharacterName;

        public List<Item> Inventory { get; set; }

        public Player()
        {
            CharacterName = NameCharacter();
            Score = 0;
            Inventory = new List<Item>();
        }

        public string NameCharacter()
        {
            Console.WriteLine("Character Name?");
            string CharacterName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hello " + CharacterName + "!");
            return CharacterName;
        }

        public void PlayerInventory(Player player)
        {
            Console.WriteLine("What to use?");
            for(int i =0; i < player.Inventory.Count; i++)
            {
                Console.WriteLine($"{player.Inventory[i].Name}\n {player.Inventory[i].Description}");
                Score++;
            }
        }

    

        
    }
    
}