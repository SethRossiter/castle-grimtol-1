using System;
using System.Collections.Generic;
using CastleGrimtol.Game;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game.Game game = new Game.Game();
            bool playing = true;
            game.Setup();
            Console.WriteLine("\n");
            game.CreateRooms();
            Console.WriteLine($"{game.CurrentRoom.Name}:\n{game.CurrentRoom.Description}");
            
            // Console.WriteLine($"{game.CurrentRoom.Name}:\n{game.CurrentRoom.Description}");

            while(playing)
            {
                // Console.WriteLine("What would you like to do?");
                string userChoice = game.GetUserInput().ToLower();
                string[] userInput = userChoice.Split(' ');
                Room newRoom;
                game.CurrentRoom.Exits.TryGetValue(userInput[0], out newRoom);
                    
                if(userInput[0] == "look" || userInput[0] == "l")
                    {
                        game.Look(game.CurrentRoom);        
                    }
                
                else if(userInput[0] ==  "t" || userInput[0] == "take")
                {
                    
                    game.Take(userInput[1]);
                }
                  else if (userInput[0] == "u" || userInput[0] == "use")
                {
                    game.UseItem(userInput[1]);
                    game.Look(game.CurrentRoom);
                }
                else if(userInput[0] == "i" || userInput[0] == "inventory")
                    {
                       game.CurrentPlayer.PlayerInventory(game.CurrentPlayer);
                    }

                else if(userInput[0] == "h" || userInput[0] == "help")
                    {                        
                         game.Help();                           
                    }

                else if(userInput[0] == "r" || userInput[0] == "reset")
                {
                    game.Reset();
                }
                
                
                else if(userInput[0] == "quit" || userInput[0] == "q")
                    {                
                        game.Quit();                      
                    }
                    
                    

                else if(newRoom != null)
                {  
                    game.CurrentRoom = newRoom;
                    System.Console.WriteLine("\n");
                    Console.Clear();
                    game.Look(game.CurrentRoom);
                }

                else
                {
                    Console.WriteLine("You're not able to do that!");
                }
               
            }
        }
    }
}



               