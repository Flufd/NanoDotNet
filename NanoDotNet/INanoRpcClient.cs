using System.Collections.Generic;
using System.Threading.Tasks;

namespace NanoDotNet
{
    public interface INanoRpcClient
    {
        Task<AccountBalance> GetAccountBalanceAsync(NanoAccount account);
        Task<AccountInformationResponse> GetAccountInformationAsync(NanoAccount account, bool fetchRepresentative = false, bool fetchWeight = false, bool fetchPending = false);
        Task<BlockResponse> SendAsync(NanoWallet wallet, NanoAccount sourceAddress, NanoAccount destinationAddress, NanoAmount amount);
        Task<IsValidResponse> UnlockWalletAsync(NanoWallet wallet, string password);
        Task<IsValidResponse> ValidateWalletPasswordAsync(NanoWallet wallet);
        Task<NanoAccount> CreateAccountAsync(NanoWallet wallet, bool work = true);
        Task<NanoAccount> GetAccountAsync(string publicKey);
        Task<PublicKey> GetAccountPublicKeyAsync(NanoAccount account);
        Task<PendingAccountBlocks> GetAccountsPendingAsync(IEnumerable<NanoAccount> accounts, int count);
        Task<BlockResponse> ReceiveAsync(NanoWallet wallet, NanoAccount nanoAccount, string block);
        Task<BlockCollectionResponse> GetBlocksAsync(IEnumerable<string> hashes);
        Task<BlockInfoCollectionResponse> GetBlockInfosAsync(IEnumerable<string> hashes);
        Task<bool> SetReceiveMinumum(NanoAmount amount);
        Task<NanoAccount> GetBlockAccount(string blockHash);
    }
}