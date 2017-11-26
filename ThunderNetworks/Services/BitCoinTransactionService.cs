using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;
using QBitNinja.Client;
using ThunderNetworks.Models;

namespace ThunderNetworks.Services
{
    public class BitCoinTransactionService
    {
        private static BitcoinSession _bitCoinSession;

        public BitCoinTransactionService(BitcoinSession bitCoinSession)
        {
            _bitCoinSession = bitCoinSession;
        }

        public void GetTransactionInfo(string transactionID)
        {
            int confirmations = 0;

            var client = new QBitNinjaClient(_bitCoinSession.BitCoinNetwork);
            var transactionId = uint256.Parse(transactionID);
            var transactionResponse = client.GetTransaction(transactionId).Result;

            if (transactionResponse.Block != null)
            {
                confirmations = transactionResponse.Block.Confirmations;
            }

            Console.WriteLine($"Confirmations: {confirmations}");


            //////////////////////////////////
            var receivedCoins = transactionResponse.ReceivedCoins;
            OutPoint outPointToSpend = null;

            foreach (var coin in receivedCoins)
            {
                if (coin.TxOut.ScriptPubKey == _bitCoinSession.PrivateKey.ScriptPubKey)
                {
                    outPointToSpend = coin.Outpoint;
                }
            }

            if (outPointToSpend == null)
                throw new Exception("TxOut doesn't contain our ScriptPubKey");

            Console.WriteLine("We want to spend outpoint {0}", outPointToSpend.N + 1);

            Transaction transaction = new Transaction();
            transaction.Inputs.Add(new TxIn()
            {
                PrevOut = outPointToSpend
            });
        }
    }
}
