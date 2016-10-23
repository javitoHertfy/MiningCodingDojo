using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javito.MiningCodingDojo.Domain;

namespace Javito.MiningCodingDojo.ServiceLibrary.Contracts
{
    public interface IMinerManagementAppService
    {
        List<Miner> GetMinersLogged();

        void InsertMiner(string name);
      
        Miner GetMiner(string name);     

        Miner GetMinerLogged(string name);      

        void LoginMine(string name);

        void LogoutMine(string name);
       
    }
}
