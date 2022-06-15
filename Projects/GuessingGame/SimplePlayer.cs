using System;
using System.Threading;
using System.Threading.Tasks;


namespace GuessingGame
{
    
    public class SimplePlayer : Player
    {
        private static object locker = new object();
        public SimplePlayer()
        {
            Name = "SimplePlayer";
        }

        public override Task RollNumbers(CancellationToken cts)
        {
            int current = MinMax.Min;
            while (!cts.IsCancellationRequested)
            {
                lock (locker)
                {
                    Console.WriteLine($"SimplePlayer guessed {current}");   
                }
                if (current == MinMax.SearchValue)
                {
                    Console.WriteLine($"{Name}, founded value first! It is {ResultValue = MinMax.SearchValue}");
                    break;
                }

                current++;
                //Thread.Sleep(10);
            }

            return Task.CompletedTask;
        }
    }
}
