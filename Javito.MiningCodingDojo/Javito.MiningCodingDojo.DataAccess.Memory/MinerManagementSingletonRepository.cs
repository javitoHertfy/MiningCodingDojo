using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javito.MiningCodingDojo.DataAccess.Memory
{
    using System;
    using Javito.MiningCodingDojo.Domain;

    public sealed class MinerManagementSingletonRepository
    {
        private static volatile MinerManagementSingletonRepository instance;
        private static object syncRoot = new Object();

        private MinerManagementSingletonRepository() { }

        public static MinerManagementSingletonRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MinerManagementSingletonRepository();
                            instance.Miners = new List<Miner>();
                            instance.MinersLoggedIntoMine = new List<Miner>();                            
                        }
                            
                    }
                }

                return instance;
            }
        }

        public List<Miner> Miners { get; set; }
        public List<Miner> MinersLoggedIntoMine { get; set; }       
    }
}
