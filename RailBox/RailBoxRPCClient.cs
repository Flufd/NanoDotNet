using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RailBox
{
    /// <summary>
    /// Provides methods to call RPC methods on a RaiBlocks node
    /// </summary>
    public class RailBoxRpcClient : IDisposable, IRailBoxRpcClient
    {
        private readonly string nodeRpcEndpoint;
        private HttpClient httpClient;
        private JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()               
            }
        };

        public RailBoxRpcClient(string nodeRpcEndpoint)
        {
            this.nodeRpcEndpoint = nodeRpcEndpoint;
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(nodeRpcEndpoint)
            };
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        private async Task<T> PostActionAsync<T>(object action)
        {
            var content = new StringContent(JsonConvert.SerializeObject(action, jsonSerializerSettings), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("", content);
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResponse, jsonSerializerSettings);
        }

        /// <inheritdoc />
        public async Task<AccountBalance> GetAccountBalanceAsync(RaiAccount account)
        {
            return await PostActionAsync<AccountBalance>(new
            {
                Account = account.Account,
                Action = ActionTypes.AccountBalance
            });
        }

        /// <inheritdoc />
        public async Task<AccountInformationResponse> GetAccountInformationAsync(RaiAccount account, bool fetchRepresentative = false, bool fetchWeight = false, bool fetchPending = false)
        {
            return await PostActionAsync<AccountInformationResponse>(new
            {
                Account = account.Account,
                Action = ActionTypes.AccountInfo,
                Pending = fetchPending,
                Weight = fetchWeight,
                Representative = fetchRepresentative
            });
        }

        /// <inheritdoc />
        public async Task<IsValidResponse> UnlockWalletAsync(RaiWallet wallet, string password)
        {
            return await PostActionAsync<IsValidResponse>(new
            {               
                Action = ActionTypes.PasswordEnter,
                Password = password,
                Wallet = wallet.Wallet
            });
        }

        /// <inheritdoc />
        public async Task<IsValidResponse> ValidateWalletPasswordAsync(RaiWallet wallet)
        {
            return await PostActionAsync<IsValidResponse>(new
            {
                Action = ActionTypes.PasswordValid,
                Wallet = wallet.Wallet
            });
        }

        /// <inheritdoc />
        public async Task<BlockResponse> SendAsync(RaiWallet wallet, RaiAccount sourceAddress, RaiAccount destinationAddress, RaiAmount amount)
        {
            return await PostActionAsync<BlockResponse>(new
            {
                Action = ActionTypes.Send,
                Wallet = wallet.Wallet,
                Source = sourceAddress.Account,
                Destination = destinationAddress.Account,
                Amount = amount.Raw
            });
        }

        /// <inheritdoc />
        public async Task<RaiAccount> CreateAccountAsync(RaiWallet wallet, bool work = true)
        {
            return await PostActionAsync<RaiAccount>(new
            {
                Action = ActionTypes.AccountCreate,
                Wallet = wallet.Wallet,
                Work = work
            });
        }

        /// <inheritdoc />
        public async Task<RaiAccount> GetAccountAsync(string publicKey)
        {
            return await PostActionAsync<RaiAccount>(new
            {
                Action = ActionTypes.AccountGet,               
                Key = publicKey
            });
        }

        /// <inheritdoc />
        public async Task<AccountHistory> GetAccountHistoryAsync(RaiAccount account, int count)
        {
            return await PostActionAsync<AccountHistory>(new
            {
                Action = ActionTypes.AccountHistory,
                Account = account.Account,
                Count = count
            });
        }

        /// <inheritdoc/>
        public async Task<RaiPublicKey> GetAccountPublicKey(RaiAccount account)
        {
            return await PostActionAsync<RaiPublicKey>(new
            {
                Action = ActionTypes.AccountKey,
                Account = account.Account
            });
        }
    }
}
