# NanoDotNet
.NET Library for working with Nano (Formerly RaiBlocks)

Features
----
* Wrapper around RPC calls, create a `NanoRpcClient` and call the RPC methods on it
* Utilities to generate private keys and Nano addresses from seeds

Roadmap
----
* RPC Client (In progress)
  * Add more RPC calls
  
* Block creation and signing

Required Dependencies
----
Json.net



Example usage
----
```c#
using (var client = new NanoRpcClient("http://localhost:7076"))
{
    var accountBalance = await client.GetAccountBalanceAsync(new NanoAccount("xrb_abc123abc123abc123..."));  
    Console.WriteLine($"The account balance is {accountBalance.Balance.ToString(AmountBase.Mxrb)} Mxrb");
    Console.WriteLine($"The account balance is {accountBalance.Balance.ToString(AmountBase.Nano)} Nano");
    
    var nextBlock = await client.SendAsync(
        new NanoWallet("ABC123ABC123...."), // Wallet key
        new NanoAccount("xrb_abc123abc123abc123..."), // Source Address
        new NanoAccount("xrb_123abc123abc123abc..."), // Destination Address
        new NanoAmount(100, AmountBase.Nano) // Amount to send
    );
    
    Console.WriteLine($"The next block hash is {nextBlock.Block}");
}
```


Contribution
----
Pull requests are appreciated
