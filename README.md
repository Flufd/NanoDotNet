# NanoDotNet
.NET Library for working with Nano (Formerly RaiBlocks)

Example usage
----
```c#
using (var client = new RailBoxRpcClient("http://localhost:7076"))
{
    var accountBalance = await client.GetAccountBalanceAsync("xrb_abc123abc123abc123...");  
    Console.WriteLine($"The account balance is {accountBalance.Balance.ToString(RaiAmountBase.Mxrb)} Mxrb");
    
    
}
```


Required Dependencies
----
Json.net


Roadmap
----
* RPC Client
  * Add more RPC calls
  
* Block creation and signing

Contribution
----
Pull requests are appreciated
