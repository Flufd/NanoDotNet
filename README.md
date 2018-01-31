# NanoDotNet
.NET Library for working with Nano (Formerly RaiBlocks)

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
    
    Console.WriteLine($"The account balance is {accountBalance.Balance.ToString(AmountBase.Mxrb)} Mxrb");
}
```


Contribution
----
Pull requests are appreciated
