using System;
using System.Collections.Generic;
using System.Threading;


namespace GuessingGame
{
    public static class MinMax
    {
        private static object _syncLock = new ();
        public static int Min;
        public static int Max;
        public static int SearchValue;
        public static HashSet<int> GuessedNumbers = new();
        

        public static void GetMinMax()
        {
            Console.WriteLine("Enter Min value");
            Min = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Max value");
            Max = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            SearchValue = rnd.Next(Min, Max);
            Console.WriteLine($"The value we are trying to find {SearchValue}\n");
        }

    }

}


