using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RailBox.Models;
using System;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RailBox
{
    /// <summary>
    /// TEST
    /// </summary>
    public class RailBoxClient : IDisposable
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

        public RailBoxClient(string nodeRpcEndpoint)
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

        public async Task<AccountBalance> AccountBalance(string account)
        {
            return await PostAction<AccountBalance>(new
            {
                Account = account,
                Action = ActionTypes.AccountBalance
            });
        }

        public async Task<AccountInformation> AccountInformation(string account, bool fetchRepresentative = false, bool fetchWeight = false, bool fetchPending = false)
        {
            return await PostAction<AccountInformation>(new
            {
                Account = account,
                Action = ActionTypes.AccountInfo,
                Pending = fetchPending,
                Weight = fetchWeight,
                Representative = fetchRepresentative
            });
        }

        public async Task<IsValidResponse> UnlockWallet(string wallet, string password)
        {
            return await PostAction<IsValidResponse>(new
            {               
                Action = ActionTypes.PasswordEnter,
                Password = password,
                Wallet = wallet
            });
        }

        public async Task<IsValidResponse> ValidateWalletPassword(string wallet, string password)
        {
            return await PostAction<IsValidResponse>(new
            {
                Action = ActionTypes.PasswordValid,   
                //Password = password,
                Wallet = wallet
            });
        }

        public async Task<BlockResponse> Send(string wallet, string sourceAddress, string destinationAddress, RaiAmount amount)
        {
            return await PostAction<BlockResponse>(new
            {
                Action = ActionTypes.Send,
                Wallet = wallet,
                Source = sourceAddress,
                Destination = destinationAddress,
                Amount = amount.Raw
            });
        }

        private async Task<T> PostAction<T>(object action)
        {
            var content = new StringContent(JsonConvert.SerializeObject(action, jsonSerializerSettings), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("", content);
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResponse, jsonSerializerSettings);
        }
    }
}
