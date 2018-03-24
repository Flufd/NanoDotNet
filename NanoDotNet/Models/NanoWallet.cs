using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public class NanoWallet
    {
        public NanoWallet()
        {

        }

        public NanoWallet(string wallet)
        {
            this.Wallet = wallet;
        }

        public string Wallet { get; set; }
    }
}