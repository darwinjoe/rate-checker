using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RateChecker.Core{
    public abstract class BaseHttpClient{
        protected HttpClient Client { get; set; }

        public string SendRequest(HttpMethod method, string url, Dictionary<String, String> headers, HttpContent content) {
            var request = new HttpRequestMessage(method, url);

            if (content != null){
                request.Content = content;
            }
            else {
                request.Content = new StringContent(String.Empty);
            }

            foreach (var header in headers){
                request.Headers.Remove(header.Key);
                request.Headers.Add(header.Key, header.Value);

                //request.Content.Headers.Remove(header.Key);
                //request.Content.Headers.Add(header.Key, header.Value);
            }

            var response = Client.SendAsync(request);

            var result = response.Result.Content.ReadAsStringAsync().Result;

            //var resp = SendAsyncRequest(request);
            //resp.Wait();
            //return resp.Result;

            return result;
        }

        private async Task<string> SendAsyncRequest(HttpRequestMessage request) {
            var response = await Client.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();
        }

        protected string CreateBasicAuthorizationHeaderValue(string username, string password) {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password)) {
                return String.Empty;
            }

            var bytes = Encoding.ASCII.GetBytes(username + ":" + password);
            return "Basic " + Convert.ToBase64String(bytes);
        }

        protected string CreateBearerTokenAuthorizationHeaderValue(string token){
            if (String.IsNullOrWhiteSpace(token)){
                return String.Empty;
            }

            return "Bearer " + token;
        }
    }
}