using NanoDotNet.Crypto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NanoDotNet
{
    public static class Utils
    {
        static Utils()
        {
            xrb_addressEncoding = new Dictionary<char, string>();
            xrb_addressDecoding = new Dictionary<string, char>();


            var i = 0;
            foreach (var validAddressChar in "13456789abcdefghijkmnopqrstuwxyz")
            {
                xrb_addressEncoding[validAddressChar] = Convert.ToString(i, 2).PadLeft(5, '0');
                xrb_addressDecoding[Convert.ToString(i, 2).PadLeft(5, '0')] = validAddressChar;
                i++;
            }
        }

        private static Dictionary<char, string> xrb_addressEncoding;
        private static Dictionary<string, char> xrb_addressDecoding;


        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();
        }

        public static (PublicKey Public, byte[] Private) GetPublicPrivateKey(string seed, uint index)
        {
            var seedBytes = HexStringToByteArray(seed);

            var blake = Blake2Sharp.Blake2B.Create(new Blake2Sharp.Blake2BConfig() { OutputSizeInBytes = 32 });

            blake.Init();
            blake.Update(seedBytes);
            blake.Update(BitConverter.GetBytes(index).Reverse().ToArray());

            var privateKey = blake.Finish();
            var publicKey = Ed25519.PublicKey(privateKey);

            return (new PublicKey(publicKey), privateKey);
        }

        public static string ByteArrayToHex(byte[] bytes)
        {
            var hex = new StringBuilder();
            for (int j = 0; j < bytes.Length; j++)
            {
                hex.AppendFormat("{0:X2}", bytes[j]);
            }
            return hex.ToString();
        }

        public static string PublicKeyToAddress(byte[] publicKey)
        {
            var address = "xrb_" + XrbEncode(publicKey);

            var blake = Blake2Sharp.Blake2B.Create(new Blake2Sharp.Blake2BConfig() { OutputSizeInBytes = 5 });
            blake.Init();
            blake.Update(publicKey);
            var checksumBytes = blake.Finish();

            address += XrbEncode(checksumBytes.Reverse().ToArray(), false);

            return address;

        }

        private static string XrbEncode(byte[] bytes, bool padZeros = true)
        {
            var binaryString = padZeros ? "0000" : "";
            for (int i = 0; i < bytes.Length; i++)
            {
                binaryString += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }

            var result = "";

            for (int i = 0; i < binaryString.Length; i += 5)
            {
                result += xrb_addressDecoding[binaryString.Substring(i, 5)];
            }

            return result;
        }

        public static byte[] AddressToPublicKey(string address)
        {
            // Check length is valid
            if (address.Length != 64)
            {
                return null;
            }

            // Address must begin with xrb
            if (!address.Substring(0, 4).Equals("xrb_"))
            {
                return null;
            }

            // Remove xrb_
            var publicKeyPart = address.Substring(4, address.Length - 8);

            var binaryString = "";
            for (int i = 0; i < publicKeyPart.Length; i++)
            {
                // Decode each character into string representation of it's binary parts
                binaryString += xrb_addressEncoding[publicKeyPart[i]];
            }

            // Remove leading 4 0s
            binaryString = binaryString.Substring(4);

            // Convert to bytes
            var pk = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                // for each byte, read the bits from the binary string
                var b = Convert.ToByte(binaryString.Substring(i * 8, 8), 2);
                pk[i] = b;
            }
            return pk;
        }



    }
}
