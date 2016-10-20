using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javito.MiningCodingDojo.DataAccess.Memory;
using Javito.MiningCodingDojo.Domain;

namespace Javito.MiningCodingDojo.ServiceLibrary
{
    public class MineAppService
    {
        private readonly MinerManagementSingletonRepository minerManagementSingletonRepository;
        private readonly MineSingletonRepository mineSingletonRepository;

        public MineAppService()
        {
            minerManagementSingletonRepository = MinerManagementSingletonRepository.Instance;
            mineSingletonRepository = MineSingletonRepository.Instance;
        }

        public int CollectGold(Guid minerId)
        {
            FailureService.GetRandomException(3, ExceptionTypesEnum.InternalServerError);            
            Miner miner = minerManagementSingletonRepository.MinersLoggedIntoMine.FirstOrDefault(x => x.Id == minerId);

            if (miner != null)
            {
                miner.GoldObtained = 1;
            }
            else
            {
                throw new Exception("Miner not found in the mine, please log in again");
            }

            return miner.GoldObtained;

        }

        public void SaveGold(Guid minerId, int goldQuantity)
        {

            FailureService.GetRandomException(2, ExceptionTypesEnum.Timeout);
            Miner miner = minerManagementSingletonRepository.MinersLoggedIntoMine.FirstOrDefault(x => x.Id == minerId);            

            if (miner != null)
            {
                Miner minerCollected = mineSingletonRepository.GoldMine.Miners.FirstOrDefault(x => x.Id == minerId);
                if(minerCollected == null)
                {
                    minerCollected = new Miner(miner.Name);
                    minerCollected.Id = miner.Id;
                    minerCollected.IsLogged = miner.IsLogged;                    
                    minerCollected.GoldObtained = miner.GoldObtained;

                    mineSingletonRepository.GoldMine.Miners.Add(minerCollected);                    
                    SaveGoldIntoPocket(minerId, goldQuantity, miner, minerCollected);
                }
                else
                {
                    SaveGoldIntoPocket(minerId, goldQuantity, miner, minerCollected);
                }
                
                
            }
            else
            {
                throw new Exception("Miner not found in the mine, please log in again");
            }
        }

        private void SaveGoldIntoPocket(Guid minerId, int goldQuantity, Miner miner, Miner minerCollected)
        {
            if (miner.GoldObtained == goldQuantity)
            {
                if (mineSingletonRepository.GoldMine.GoldLeft > 0)
                {
                    mineSingletonRepository.GoldMine.GoldLeft = mineSingletonRepository.GoldMine.GoldLeft - goldQuantity;
                    minerCollected.GoldObtained = minerCollected.GoldObtained + goldQuantity;
                    miner.GoldObtained = 0;
                }
                else
                {
                    throw new Exception("Mine is empty!");
                }
                
            }
            else
            {
                throw new Exception(string.Format("Miner with Id {0} is a cheater!!", minerId));
            }
        }

        public IEnumerable<Miner> GetResults()
        {
           return mineSingletonRepository.GoldMine.Miners.OrderByDescending(x => x.GoldObtained);
        }

        public int GetGoldLeft()
        {
            return mineSingletonRepository.GoldMine.GoldLeft;
        }
    }
}
