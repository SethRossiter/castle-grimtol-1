using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public interface IGame
    {
        Room CurrentRoom { get; set; }
        Player CurrentPlayer { get; set; }
        void Setup();
        void Reset();
        // void Quit();
        // void Help();
        // void Go(string direction);
        // void Look();
        // void Take(string item);
    
        
        //No need to Pass a room since Items can only be used in the CurrentRoom
        void UseItem(string itemName);
    }
}
