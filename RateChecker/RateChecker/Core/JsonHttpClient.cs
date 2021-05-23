using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RateChecker.Core{
    public class JsonHttpClient : BaseHttpClient, IHttpClient{
        private Encoding defaultEncoding = Encoding.UTF8;
        private string defaultMediaType = "application/json";
        private string authorizationHeaderKey = "Authorization";

        public JsonHttpClient() {
            Client = new HttpClient();
        }

        public string SendGetRequest(ApiConfiguration apiConfiguration){
            var authorizationHeader = getAuthorizationHeader(apiConfiguration);

            var responseString = SendRequest(HttpMethod.Get, apiConfiguration.getUrl(), authorizationHeader, new StringContent(String.Empty, defaultEncoding, defaultMediaType));

            return responseString;
        }

        public string SendPostRequest(ApiConfiguration apiConfiguration, string body) {
            var authorizationHeader = getAuthorizationHeader(apiConfiguration);

            var responseString = SendRequest(HttpMethod.Post, apiConfiguration.getUrl(), authorizationHeader, new StringContent(body, defaultEncoding, defaultMediaType));

            return responseString;
        }

        private Dictionary<string, string> getAuthorizationHeader(ApiConfiguration apiConfiguration){
            var headers = new Dictionary<String, String>();
            
            var tokenHeaderValue = CreateBearerTokenAuthorizationHeaderValue(apiConfiguration.Token);

            if (!String.IsNullOrWhiteSpace(tokenHeaderValue)){
                headers.Add(authorizationHeaderKey, tokenHeaderValue);
            }
            else {
                var basicAuthorizationHeaderValue = CreateBasicAuthorizationHeaderValue(apiConfiguration.Username, apiConfiguration.Password); 
                
                if (!String.IsNullOrWhiteSpace(basicAuthorizationHeaderValue)){
                    headers.Add(authorizationHeaderKey, basicAuthorizationHeaderValue);
                }
            }
            
            return headers;
        }
    }
}