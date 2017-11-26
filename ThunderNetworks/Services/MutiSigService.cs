using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;
using ThunderNetworks.Models;

namespace ThunderNetworks.Services
{
    public class MutiSigService
    {
        private Network _bitCoinNetwork { get; set; }

        public MutiSigService(Network bitCoinNetwork)
        {
            _bitCoinNetwork = bitCoinNetwork;
        }

        public MultiSigAddress GenerateNewAddress(int signaturesRequired, int totalSignatures)
        {
            MultiSigAddress multiSigAddress = new MultiSigAddress();
            List<PubKey> pubKeys = new List<PubKey>();

            for (int i = 0; i < totalSignatures; i++)
            {
                //Used to create the Script
                Key key = new Key();
                pubKeys.Add(key.PubKey);

                //Add the secret to the
                multiSigAddress.Wifs.Add(key.GetWif(_bitCoinNetwork));
            }
           
            Script scriptPubKey = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(2, pubKeys.ToArray() );

            //Get the public bitcoin address multiSigAddress
            multiSigAddress.BitcoinAddress = scriptPubKey.GetScriptAddress(_bitCoinNetwork);

            Console.WriteLine(multiSigAddress.BitcoinAddress);
            return multiSigAddress;

        }

        public MultiSigAddress GetExistingAddress()
        {
           
            BitcoinSecret bobWif = new BitcoinSecret("cQYnRmBjg5FKWgyu6qDoyoiG3cbLdGAxBqG9TiMcsYzt3PqSLSz2");
            BitcoinSecret aliceWif = new BitcoinSecret("cTXKcDiqXjwiFq4Z3LWUsgcQqLN9SZLxzieceRn15TdYBhDKiyFY");
            BitcoinSecret satoshiWif = new BitcoinSecret("cSn31beqsHRvx9XtEqMuMdRMK46HiSaQ6yZf8uXF7VNE7Cg92H6z");

            //Add Secret Keys
            MultiSigAddress multiSigAddress = new MultiSigAddress();

            multiSigAddress.Wifs.Add(bobWif);
            multiSigAddress.Wifs.Add(aliceWif);
            multiSigAddress.Wifs.Add(satoshiWif);

            Script scriptPubKey = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(2, new[] { bobWif.PubKey, aliceWif.PubKey, satoshiWif.PubKey });

            multiSigAddress.BitcoinAddress = scriptPubKey.GetScriptAddress(_bitCoinNetwork);

            Console.WriteLine(multiSigAddress.BitcoinAddress); //2NG5GAyy2vLW3tabPABTo84CkpgBPpEPEYu

            return multiSigAddress;

        }

    }
}
