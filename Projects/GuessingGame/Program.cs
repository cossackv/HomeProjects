using System;
using System.Collections.Generic;

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] players =
            {
                new SimplePlayer(),
                new RandomPlayer(),
                new RandomSmartPlayer(),
                //new RandomCheaterPlayer()
                
            };
            Game game = new Game(players);
            game.Run();

        }
    }
}
