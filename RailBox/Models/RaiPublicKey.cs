using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RailBox
{
    public class RaiPublicKey
    {
        public string Key { get; set; }

        public byte[] Bytes
        {
            get
            {
                // TODO: Store as bytes instead of string
                return Utils.HexStringToByteArray(Key);
            }
        }


        static RaiPublicKey()
        {
            xrb_addressEncoding = new Dictionary<char, string>();

            var i = 0;
            foreach (var validAddressChar in "13456789abcdefghijkmnopqrstuwxyz")
            {
                xrb_addressEncoding[validAddressChar] = Convert.ToString(i, 2).PadLeft(5, '0');
                i++;
            }
        }

        private static Dictionary<char, string> xrb_addressEncoding;

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
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
