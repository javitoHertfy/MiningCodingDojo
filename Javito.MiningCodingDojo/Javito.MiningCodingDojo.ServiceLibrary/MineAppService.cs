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
            FailureService.GetRandomException(3);
            int reward = 0;
            Miner miner = minerManagementSingletonRepository.MinersLoggedIntoMine.FirstOrDefault(x => x.Id == minerId);

            if (miner != null)
            {
                reward = 1;
            }

            return reward;

        }

        public void SaveGold(Guid minerId, int goldQuantity)
        {

            FailureService.GetRandomException(2);
            Miner miner = minerManagementSingletonRepository.MinersLoggedIntoMine.FirstOrDefault(x => x.Id == minerId);
            Miner minerCollected = mineSingletonRepository.GoldMine.Miners.FirstOrDefault(x => x.Id == minerId);

            if (miner != null)
            {
                mineSingletonRepository.GoldMine.GoldLeft = mineSingletonRepository.GoldMine.GoldLeft - goldQuantity;
                minerCollected.GoldObtained = minerCollected.GoldObtained + goldQuantity;
            };
        }
    }
}
