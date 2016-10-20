using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javito.MiningCodingDojo.Domain
{
    public class Miner
    {
        public Miner(string name)
        {
            this.name = name;
            this.id = Guid.NewGuid();
            this.isLogged = false;
            this.goldObtained = 0;
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private bool isLogged;
        public bool IsLogged
        {
            get { return isLogged; }
            set { isLogged = value; }
        }

        private int goldObtained;
        public int GoldObtained
        {
            get { return goldObtained; }
            set { goldObtained = value; }
        }
    }
}
