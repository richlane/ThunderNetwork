using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;


namespace ThunderNetworks.Models
{

    public class BitcoinSession
    {
        public Network BitCoinNetwork { get; set; }

        public BitcoinSecret Wif { get; set; }

        public BitcoinPubKeyAddress Address { get; set; }

        public BitcoinSession(Network bitCoinNetwork)
        {
            BitCoinNetwork = bitCoinNetwork;
            getPrivateKeyAndAddress();
        }

        private void getPrivateKeyAndAddress()
        {
            Wif = new BitcoinSecret("cSrSUDPKdEBZh9x2MeVaCu6Ce5xiFApU7sQuiS4mLUECJ5xqVqzi");
            Address = Wif.GetAddress();

            Console.WriteLine($"Key: {Wif}"); //  cSrSUDPKdEBZh9x2MeVaCu6Ce5xiFApU7sQuiS4mLUECJ5xqVqzi
            Console.WriteLine($"Address: {Address}"); // n15TeiYwV65SQjaZnVc1E2g79pVjgSDCQV
                                                       
        }


        private void generateNewPrivateKeyAndAddress()
        {
            Key privateKey = new Key();
            Wif = privateKey.GetWif(BitCoinNetwork);
            Address = Wif.GetAddress();

            Console.WriteLine(Wif);
            Console.WriteLine(Address);
        }

    }
}
