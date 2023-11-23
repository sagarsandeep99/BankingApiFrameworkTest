using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Coding.Assignment.Utils
{
    public class Helper
    {
        readonly RestClient _client;

        public Helper(string baseUrl)
        { 
           var options = new RestClientOptions(baseUrl);
           _client = new RestClient(options);
        }

        public T ParseJson<T>(string filePath) 
        { 
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }
        public T GetContent<T>(RestResponse response) where T : class
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<RestResponse> CreateAccount<T>(T payload) where T : class
        {
            var request = new RestRequest(Constant.EndPoints.CreateAccount, Method.Post);
            request.AddBody(payload);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DeleteAccount(string AccountNo)
        {
            var request = new RestRequest(Constant.EndPoints.DeleteAccount, Method.Delete);
            request.AddUrlSegment(AccountNo, AccountNo);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DepositeAmount<T>(T payload) where T : class
        {
            var request = new RestRequest(Constant.EndPoints.DepositeAmount, Method.Put);
            request.AddBody(payload);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> WithdrawAmount<T>(T payload) where T : class
        {
            var request = new RestRequest(Constant.EndPoints.WithdrawAmount, Method.Put);
            request.AddBody(payload);
            return await _client.ExecuteAsync(request);
        }

    }
}
