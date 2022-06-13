using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace GuessingGame
{
    public class Game
    {
        private readonly CancellationTokenSource _cancellationToken = new();
        private readonly Player[] _players;

        public Game(Player[] players)
        {
            _players = players;
        }


        public void Run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            MinMax.GetMinMax();
            var tasks = new List<Task>();

            if (_players.Length > 0)
            {
                tasks.AddRange(_players.Select(player => Task.Factory.StartNew(() => player.RollNumbers(_cancellationToken.Token))));
            }

            Task.WaitAny(tasks.ToArray());
            _cancellationToken.Cancel();
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine("Operation time in milliseconds: " + watch.ElapsedMilliseconds);
        }
    }
}
