using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace GuessingGame
{
    public class RandomSmartPlayer : Player
    {
        private static object _lock = new();
        public static HashSet<int> setOfNumbers = new();
        public RandomSmartPlayer()
        {
            Name = "RandomSmartPlayer";
        }

        public override Task RollNumbers(CancellationToken cts)
        {
            var rnd = new Random();
            
            while (!cts.IsCancellationRequested)
            {

                var num = rnd.Next(MinMax.Min, MinMax.Max);

                if (!setOfNumbers.Contains(num))
                {
                    setOfNumbers.Add(num);
                    Console.WriteLine($"RandomSmartPlayer Guessed {num} ");
                }
                else
                {
                    continue;
                }
                if (num == MinMax.SearchValue)
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

