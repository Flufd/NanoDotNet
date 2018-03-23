using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NanoDotNet
{
    public class PublicKey
    {
        public PublicKey(byte[] bytes)
        {
            Bytes = bytes;
        }

        public string Key => Utils.ByteArrayToHex(Bytes);

        public byte[] Bytes { get; }

        private string address;
        public string Address
        {
            get
            {
                if (address == null)
                {
                    address = Utils.PublicKeyToAddress(Bytes);
                }
                return address;
            }

        }
    }
}
