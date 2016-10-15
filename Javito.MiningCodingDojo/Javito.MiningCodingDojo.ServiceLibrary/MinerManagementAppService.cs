using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javito.MiningCodingDojo.DataAccess.Memory;

namespace Javito.MiningCodingDojo.ServiceLibrary
{
    public class MinerManagementAppService
    {
        private readonly MinerManagementSingletonRepository minerManagementSingletonRepository;

        public MinerManagementAppService()
        {
            minerManagementSingletonRepository = MinerManagementSingletonRepository.Instance;
        }

        public List<string> GetMiners()
        {
            return this.minerManagementSingletonRepository.Miners;
        }

        public void InsertMiner(string name)
        {
           this.minerManagementSingletonRepository.Miners.Add(name);            
        }

    }
}
