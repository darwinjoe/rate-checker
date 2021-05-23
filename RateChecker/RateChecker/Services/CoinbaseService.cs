using Newtonsoft.Json;
using RateChecker.Core;
using RateChecker.Models;
using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RateChecker.Services{
    public class CoinbaseService{
        private IHttpClient HttpClient { get; set; }
        private ApiConfiguration ApiConfiguration { get; set; }

        public CoinbaseService(String baseUrl) : 
            this(new JsonHttpClient(), new ApiConfiguration(){BaseUrl = baseUrl})
        {}

        public CoinbaseService(IHttpClient httpClient, ApiConfiguration apiConfiguration){
            this.HttpClient = httpClient;
            this.ApiConfiguration = apiConfiguration;
        }

        public IEnumerable<Currency> GetAllCurrencies() {
            ApiConfiguration.SuffixUrl = "/currencies";

            var response = HttpClient.SendGetRequest(ApiConfiguration);

            if (String.IsNullOrWhiteSpace(response)) {
                return new List<Currency>();
            }

            var definition = new { data = new [] { new { id = "", name = "" } } };
            var currencies = JsonConvert.DeserializeAnonymousType(response, definition);

            return currencies.data.ToList().Select(d => new Currency() {
                Code = d.id,
                Name = d.name
            });
        }

        public IEnumerable<ExchangeRate> GetAllExchangeRates(String baseCurrency){
            ApiConfiguration.SuffixUrl = String.Format("/exchange-rates?currency={0}", baseCurrency);

            var response = HttpClient.SendGetRequest(ApiConfiguration);

            if (String.IsNullOrWhiteSpace(response)){
                return new List<ExchangeRate>();
            }

            var definition = new { data = new[] { new { currency = "", rates = new Dictionary<string, string>() } } };
            var rates = JsonConvert.DeserializeAnonymousType(response, definition);

            return rates.data.ToList().Select(d => new ExchangeRate()
            {
                Rate = d.rates.Count,
                Date = new DateTime()
            });
        }

        public String GetRawResponse() { 
            return HttpClient.SendGetRequest(ApiConfiguration);
        }
    }
}