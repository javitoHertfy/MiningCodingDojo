using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javito.MiningCodingDojo.Domain;
using Javito.MiningCodingDojo.Domain.Contracts;

namespace Javito.MiningCodingDojo.DataAccess.Memory
{
    public sealed class MineSingletonRepository: IMineManagement
    {
        private static volatile MineSingletonRepository instance;
        private static object syncRoot = new Object();

        private MineSingletonRepository() { }

        public static MineSingletonRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MineSingletonRepository();
                            instance.GoldMine = new GoldMine();
                        }
                            
                    }
                }

                return instance;
            }
        }

        public GoldMine GoldMine { get; set; }
    }
}
