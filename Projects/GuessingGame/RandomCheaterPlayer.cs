using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuessingGame
{
    internal class RandomCheaterPlayer : Player
    {
        private static object _lock = new();
        public static HashSet<int> cheaterSet = new();
        public RandomCheaterPlayer()
        {
            Name = "Cheater";
        }

        public override Task RollNumbers(CancellationToken cts)
        {
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {

                var num = rnd.Next(MinMax.Min, MinMax.Max);

                if (!cheaterSet.Contains(num) && !MinMax.GuessedNumbers.Contains(num))
                {
                    cheaterSet.Add(num);
                    Console.WriteLine($"Cheater Guessed {num}");
                }

                if (cheaterSet.Contains(MinMax.SearchValue))
                {
                    Console.WriteLine($"{Name}, founded value first! It is {ResultValue = MinMax.SearchValue}");
                    break;
                }

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
