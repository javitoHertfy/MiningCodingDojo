using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        
        public static Exception GetRandomException(int multiplier, ExceptionTypesEnum exceptionType)
        {
            if (RandomNumber(1, 10) % multiplier == 0)
            {
                if (exceptionType == ExceptionTypesEnum.Timeout)
                {
                    Thread.Sleep(15);
                    throw new Exception("Timeout exception");
                }
                if (exceptionType == ExceptionTypesEnum.ServiceUnavailable)
                {
                    throw new Exception("Service unavailable");
                }
                if (exceptionType == ExceptionTypesEnum.InternalServerError)
                {
                    throw new Exception("Internal Server Error");
                }
            }
            return null;
        }        
    }
}
