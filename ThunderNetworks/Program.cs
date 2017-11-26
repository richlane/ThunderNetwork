using System;
using NBitcoin;
using QBitNinja.Client;
using ThunderNetworks.Models;
using ThunderNetworks.Services;
using System.Collections.Generic;

namespace ThunderNetworks
{
    class Program
    {
 
        static void Main(string[] args)
        {
            //Specify bitcoin network
            Network network = Network.TestNet;

            KeyService keyService = new KeyService(network);
         
            //Generates a brand new bitcoin address and private keys.
            MultiSigAddress address2 = keyService.GenerateNewAddress(2, 3);

            //Returns existing bitcoin address using existing private keys.
            MultiSigAddress address1 = keyService.GetExistingAddress();

            //Create me some private keys for fun
            List<BitcoinSecret> keys = keyService.CreatePrivateKeys(3);


            ///////////////////////////////////////////
            //Ignore this stuff. Just testing out some ideas.

            //_bitcoinSession = new BitcoinSession(_network);

            //BitCoinTransactionService bcService = new BitCoinTransactionService(_bitCoinSession);
            //bcService.GetTransactionInfo("1f5dd12cfc57647bc2fe12832582fda1e46eb6cb1ea1b6cce35d1817ac06c691");


            Console.ReadLine();
        }

       
     }
}
