using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox
{
    public class RaiAccount
    {
        public RaiAccount(string xrb_address)
        {
            // TODO: Validate address
            this.Account = xrb_address;
        }

        public string Account { get; set; }
    }
}
