using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;


namespace ThunderNetworks.Models
{
    public class MultiSigAddress
    {
        public BitcoinScriptAddress BitcoinAddress { get; set; }

        public List<BitcoinSecret> Wifs { get; set; }

        public MultiSigAddress()
        {
            Wifs = new List<BitcoinSecret>();
        }
    }
}
