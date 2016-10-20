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

        public List<Miner> GetMinersLogged()
        {            
            return this.minerManagementSingletonRepository.MinersLoggedIntoMine;
        }

        public void InsertMiner(string name)
        {
           FailureService.GetRandomException(5, ExceptionTypesEnum.Timeout);
           if(!minerManagementSingletonRepository.Miners.Any(x=>x.Name == name))
           {
               this.minerManagementSingletonRepository.Miners.Add(new Miner(name));            
           }
           else
           {
               throw new Exception("The name has already been chosen be more creative!");
           }
           
        }

        public Miner GetMiner(string name)
        {
            return this.minerManagementSingletonRepository.Miners.FirstOrDefault(x => x.Name == name);
        }

        public Miner GetMinerLogged(string name)
        {
            return this.minerManagementSingletonRepository.MinersLoggedIntoMine.FirstOrDefault(x => x.Name == name);
        }

        public void LoginMine(string name)
        {
            FailureService.GetRandomException(3, ExceptionTypesEnum.ServiceUnavailable);
            Miner miner = this.GetMiner(name);
            if(miner != null)
            {
                miner.Id = Guid.NewGuid();
                miner.IsLogged = true;
                this.minerManagementSingletonRepository.MinersLoggedIntoMine.Add(miner);
            }                
            else
                throw new Exception("Miner not found, please register first");
        }

        public void LogoutMine(string name)
        {            
            Miner miner = this.GetMinerLogged(name);
            if (miner != null)
            {
                this.minerManagementSingletonRepository.MinersLoggedIntoMine.Remove(miner);
                miner.IsLogged = false;
            }
                
        }
    }
}
