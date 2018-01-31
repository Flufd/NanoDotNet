using System.Collections.Generic;
using System.Threading.Tasks;

namespace RailBox
{
    public interface IRailBoxRpcClient
    {
        Task<AccountBalance> GetAccountBalanceAsync(RaiAccount account);
        Task<AccountInformationResponse> GetAccountInformationAsync(RaiAccount account, bool fetchRepresentative = false, bool fetchWeight = false, bool fetchPending = false);
        Task<BlockResponse> SendAsync(RaiWallet wallet, RaiAccount sourceAddress, RaiAccount destinationAddress, RaiAmount amount);
        Task<IsValidResponse> UnlockWalletAsync(RaiWallet wallet, string password);
        Task<IsValidResponse> ValidateWalletPasswordAsync(RaiWallet wallet);
        Task<RaiAccount> CreateAccountAsync(RaiWallet wallet, bool work = true);
        Task<RaiAccount> GetAccountAsync(string publicKey);
        Task<RaiPublicKey> GetAccountPublicKeyAsync(RaiAccount account);
        Task<PendingAccountBlocks> GetAccountsPendingAsync(IEnumerable<RaiAccount> accounts, int count);
        Task<BlockResponse> ReceiveAsync(RaiWallet wallet, RaiAccount raiAccount, string block);
        Task<BlockCollectionResponse> GetBlocksAsync(IEnumerable<string> hashes);
        Task<BlockInfoCollectionResponse> GetBlockInfosAsync(IEnumerable<string> hashes);

    }
}