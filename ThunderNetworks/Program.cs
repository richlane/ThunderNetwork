using System;
using NBitcoin;
using QBitNinja.Client;
using ThunderNetworks.Models;
using ThunderNetworks.Services;

namespace ThunderNetworks
{
    class Program
    {
        private static Network _network = Network.TestNet;
        private static BitcoinSession  _bitcoinSession;

        static void Main(string[] args)
        {
            //_bitcoinSession = new BitcoinSession(_network);

            //BitCoinTransactionService bcService = new BitCoinTransactionService(_bitCoinSession);
            //bcService.GetTransactionInfo("1f5dd12cfc57647bc2fe12832582fda1e46eb6cb1ea1b6cce35d1817ac06c691");

            MutiSigService msService = new MutiSigService(_network);
            msService.GetExistingAddress();
            //msService.GenerateNewAddress(2,3);

            Console.ReadLine();
        }

       
     }
}
