using System.Threading.Tasks;

namespace RailBox
{
    public interface IRailBoxRpcClient
    {
        Task<AccountBalance> AccountBalance(string account);
        Task<AccountInformation> AccountInformation(string account, bool fetchRepresentative = false, bool fetchWeight = false, bool fetchPending = false);
        Task<BlockResponse> Send(string wallet, string sourceAddress, string destinationAddress, RaiAmount amount);
        Task<IsValidResponse> UnlockWallet(string wallet, string password);
        Task<IsValidResponse> ValidateWalletPassword(string wallet);
    }
}