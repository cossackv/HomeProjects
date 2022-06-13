using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuessingGame
{
    public abstract class Player
    {
        public string Name;
        public static int ResultValue;
        public abstract Task RollNumbers(CancellationToken cancellationToken);

        
    }
}
