using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javito.MiningCodingDojo.ServiceLibrary
{
    public static class FailureService
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        
        public static Exception GetRandomException()
        {
            if (RandomNumber(1, 10) % 4 == 0)
            {
                throw new TimeoutException();
            }
            return null;
        }

        public static void UnLogRandomMinerFromGoldMine()
        {
            if (RandomNumber(1, 10) % 5 == 0)
            {
                
            }
            
        }
    }
}
