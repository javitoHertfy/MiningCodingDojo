using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javito.MiningCodingDojo.DataAccess.Memory;
using Javito.MiningCodingDojo.Domain;

namespace Javito.MiningCodingDojo.ServiceLibrary
{
    public class MinerManagementAppService
    {
        private readonly MinerManagementSingletonRepository minerManagementSingletonRepository;

        public MinerManagementAppService()
        {            
            minerManagementSingletonRepository = MinerManagementSingletonRepository.Instance;
        }

        public List<Miner> GetMiners()
        {            
            return this.minerManagementSingletonRepository.Miners;
        }

        public void InsertMiner(string name)
        {
           FailureService.GetRandomException(2);
           this.minerManagementSingletonRepository.Miners.Add(new Miner(name));            
        }

        public Miner GetMiner(string name)
        {            
            return this.minerManagementSingletonRepository.Miners.FirstOrDefault(x => x.Name == name);
        }

        public void LoginMine(string name)
        {
            FailureService.GetRandomException(3);
            Miner miner = this.GetMiner(name);
            if(miner != null)
                this.minerManagementSingletonRepository.MinersLoggedIntoMine.Add(miner);
            else
                throw new Exception("Miner not found, please register first");
        }

        public void LogoutMine(string name)
        {            
            Miner miner = this.GetMiner(name);
            if (miner != null)
                this.minerManagementSingletonRepository.MinersLoggedIntoMine.Remove(miner);            
        }
    }
}
