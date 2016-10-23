using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javito.MiningCodingDojo.Domain;

namespace Javito.MiningCodingDojo.ServiceLibrary.Contracts
{
    public interface IMineAppService
    {
        int CollectGold(Guid minerId);

        void SaveGold(Guid minerId, int goldQuantity);

        void SaveGoldIntoPocket(Guid minerId, int goldQuantity, Miner miner, Miner minerCollected);

        IEnumerable<Miner> GetResults();

        int GetGoldLeft();
    }
}
