using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public class AccountHistory
    {
        public IEnumerable<AccountHistoryItem> History { get; set; }
    }
}
