using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;
using ThunderNetworks.Models;

namespace ThunderNetworks.Services
{
    public class KeyService
    {
        private Network _bitCoinNetwork { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bitCoinNetwork"></param>
        public KeyService(Network bitCoinNetwork)
        {
            _bitCoinNetwork = bitCoinNetwork;
        }


        /// <summary>
        /// Generates a brand new X of Y MultiSigAddress.  
        /// </summary>
        /// <param name="signaturesRequired"></param>
        /// <param name="totalSignatures"></param>
        /// <returns></returns>
        public MultiSigAddress GenerateNewAddress(int signaturesRequired, int totalSignatures)
        {
            //Object that will be returned
            MultiSigAddress multiSigAddress = new MultiSigAddress();

            //Needed to create the Srcript below
            List<PubKey> pubKeys = new List<PubKey>();

            //Loop the X of Y
            for (int i = 0; i < totalSignatures; i++)
            {
                //Used to create the Script
                Key key = new Key();
                pubKeys.Add(key.PubKey);

                //Add the private keys to the returned object.
                //Keys are in WIF format
                multiSigAddress.PrivateKeys.Add(key.GetWif(_bitCoinNetwork));
            }

            //This object is used to create the bitcoin address
            Script scriptPubKey = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(2, pubKeys.ToArray());

            //Get the bitcoin address
            multiSigAddress.BitcoinAddress = scriptPubKey.GetScriptAddress(_bitCoinNetwork);

            Console.WriteLine(multiSigAddress.BitcoinAddress);

            return multiSigAddress;

        }


        /// <summary>
        /// Generates any number of private keys in WIF format.
        /// </summary>
        /// <param name="totalKeys"></param>
        /// <returns></returns>
        public List<BitcoinSecret> CreatePrivateKeys(int totalKeys)
        {
            List<BitcoinSecret> privateKeys = new List<BitcoinSecret>();

            //Loop 
            for (int i = 0; i < totalKeys; i++)
            {
                Key key = new Key();
                privateKeys.Add(key.GetWif(_bitCoinNetwork));
            }

            return privateKeys;
        }

        /// <summary>
        /// Returns a MultiSigAddress using existing private keys.
        /// </summary>
        /// <returns></returns>
        public MultiSigAddress GetExistingAddress()
        {

            BitcoinSecret bobKey = new BitcoinSecret("cQYnRmBjg5FKWgyu6qDoyoiG3cbLdGAxBqG9TiMcsYzt3PqSLSz2");
            BitcoinSecret aliceKey = new BitcoinSecret("cTXKcDiqXjwiFq4Z3LWUsgcQqLN9SZLxzieceRn15TdYBhDKiyFY");
            BitcoinSecret satoshiKey = new BitcoinSecret("cSn31beqsHRvx9XtEqMuMdRMK46HiSaQ6yZf8uXF7VNE7Cg92H6z");

            MultiSigAddress multiSigAddress = new MultiSigAddress();
            multiSigAddress.PrivateKeys.Add(bobKey);
            multiSigAddress.PrivateKeys.Add(aliceKey);
            multiSigAddress.PrivateKeys.Add(satoshiKey);

            //This object is used to create the bitcoin address
            Script scriptPubKey = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(2, new[] { bobKey.PubKey, aliceKey.PubKey, satoshiKey.PubKey });

            //Get the bitcoin address
            multiSigAddress.BitcoinAddress = scriptPubKey.GetScriptAddress(_bitCoinNetwork);

            Console.WriteLine(multiSigAddress.BitcoinAddress); //2NG5GAyy2vLW3tabPABTo84CkpgBPpEPEYu

            return multiSigAddress;

        }

    }
}
