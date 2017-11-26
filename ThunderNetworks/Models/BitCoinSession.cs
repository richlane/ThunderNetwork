using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;


namespace ThunderNetworks.Models
{

    public class BitcoinSession
    {
        public Network BitCoinNetwork { get; set; }

        public BitcoinSecret PrivateKey { get; set; }

        public BitcoinPubKeyAddress Address { get; set; }

        public BitcoinSession(Network bitCoinNetwork)
        {
            BitCoinNetwork = bitCoinNetwork;
            getPrivateKeyAndAddress();
        }

        private void getPrivateKeyAndAddress()
        {
            PrivateKey = new BitcoinSecret("cSrSUDPKdEBZh9x2MeVaCu6Ce5xiFApU7sQuiS4mLUECJ5xqVqzi");
            Address = PrivateKey.GetAddress();

            Console.WriteLine($"Key: {PrivateKey}"); //  cSrSUDPKdEBZh9x2MeVaCu6Ce5xiFApU7sQuiS4mLUECJ5xqVqzi
            Console.WriteLine($"Address: {Address}"); // n15TeiYwV65SQjaZnVc1E2g79pVjgSDCQV
                                                       
        }


        private void generateNewPrivateKeyAndAddress()
        {
            Key privateKey = new Key();
            PrivateKey = privateKey.GetWif(BitCoinNetwork);
            Address = PrivateKey.GetAddress();

            Console.WriteLine(PrivateKey);
            Console.WriteLine(Address);
        }

    }
}
