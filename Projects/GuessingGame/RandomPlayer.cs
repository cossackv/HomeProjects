using System;
using System.Threading;
using System.Threading.Tasks;

namespace GuessingGame
{
    internal class RandomPlayer : Player
    {
        private static object _lock = new object();
        public RandomPlayer()
        {
            Name = "RandomPlayer";
        }

        public override Task RollNumbers(CancellationToken cts)
        {
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                var num = rnd.Next(MinMax.Min, MinMax.Max);

                if (num == MinMax.SearchValue)
                {
                    Console.WriteLine($"{Name}, founded value first! It is {ResultValue = MinMax.SearchValue}");
                    break;
                }
                
                Console.WriteLine($"RandomPlayer Guessed {num} ");
               
                lock (_lock)
                {
                    MinMax.GuessedNumbers.Add(num);
                }

                //Thread.Sleep(100);
            }

            return Task.CompletedTask;
        }
    }
}