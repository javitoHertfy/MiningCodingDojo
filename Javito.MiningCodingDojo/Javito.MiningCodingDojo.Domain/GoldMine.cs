using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javito.MiningCodingDojo.Domain
{
    public class GoldMine
    {
        public GoldMine()
        {
            miners = new List<Miner>();
            goldLeft = 10000000;
        }

        private List<Miner> miners;
        public List<Miner> Miners
        {
            get { return miners; }
            private set { miners = value; }
        }

        private int goldLeft;
        public int GoldLeft
        {
            get { return goldLeft; }
            set { GoldLeft = value; }
        }
    }
}
