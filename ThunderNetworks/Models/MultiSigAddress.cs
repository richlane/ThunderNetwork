using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;


namespace ThunderNetworks.Models
{
    public class MultiSigAddress
    {
        public BitcoinScriptAddress BitcoinAddress { get; set; }

        public List<BitcoinSecret> PrivateKeys { get; set; }

        public MultiSigAddress()
        {
            PrivateKeys = new List<BitcoinSecret>();
        }
    }
}
