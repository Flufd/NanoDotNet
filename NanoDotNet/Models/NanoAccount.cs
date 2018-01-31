using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public class NanoAccount
    {
        public NanoAccount(string xrb_address)
        {
            // TODO: Validate address
            this.Account = xrb_address;
        }

        public string Account { get; set; }
    }
}
