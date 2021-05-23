using Newtonsoft.Json;
using RateChecker.Core;
using RateChecker.Models;
using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RateChecker.Services{
    public class WiseService{
        private IHttpClient HttpClient { get; set; }
        private ApiConfiguration ApiConfiguration { get; set; }

        public WiseService(String baseUrl, String token) : 
            this(new JsonHttpClient(), new ApiConfiguration(){BaseUrl = baseUrl, Token = token})
        {}

        public WiseService(IHttpClient httpClient, ApiConfiguration apiConfiguration){
            this.HttpClient = httpClient;
            this.ApiConfiguration = apiConfiguration;
        }

        public IEnumerable<ExchangeRate> GetAllExchangeRates(String baseCurrency){
            return GetAllExchangeRates(baseCurrency, null);
        }

        public ExchangeRate GetExchangeRate(String baseCurrency, String targetCurrency){
            return GetAllExchangeRates(baseCurrency, targetCurrency).FirstOrDefault();
        }

        private IEnumerable<ExchangeRate> GetAllExchangeRates(String baseCurrency, String targetCurrency){
            var allRatesTemplate = "/rates?source={0}";
            var singleRateTemplate = "/rates?source={0}&target={1}";

            if (String.IsNullOrWhiteSpace(targetCurrency)){
                ApiConfiguration.SuffixUrl = String.Format(allRatesTemplate, baseCurrency);
            }
            else {
                ApiConfiguration.SuffixUrl = String.Format(singleRateTemplate, baseCurrency, targetCurrency);
            }
            
            var response = HttpClient.SendGetRequest(ApiConfiguration);

            return ConvertResponseToExchangeRates(response);
        }

        private IEnumerable<ExchangeRate> ConvertResponseToExchangeRates(String response) {
            if (String.IsNullOrWhiteSpace(response)){
                return null;
            }

            var definition = new[] { new { rate = 12345.67, source = "", target = "", time = "" } };
            var rates = JsonConvert.DeserializeAnonymousType(response, definition);

            return rates.Select(r => new ExchangeRate(){
                Rate = r.rate,
                Source = new Currency(){
                    Code = r.source
                },
                Target = new Currency(){
                    Code = r.target
                },
                Date = DateTime.Parse(r.time)
            });
        }

        public String GetRawResponse() { 
            return HttpClient.SendGetRequest(ApiConfiguration);
        }
    }
}