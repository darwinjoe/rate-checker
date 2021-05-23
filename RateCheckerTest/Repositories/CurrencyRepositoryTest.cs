using Newtonsoft.Json;
using RateChecker.Core;
using RateChecker.Models.CurrencyApi;
using RateChecker.Repositories;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace RateCheckerTest{
    public class CurrencyRepositoryTest{
        private readonly CurrencyRepository _repository;

        public CurrencyRepositoryTest() {
            var httpClient = new JsonHttpClient();
            var apiConfig = new ApiConfiguration(){
                BaseUrl = "https://api.coinbase.com/v2/currencies"
            };

            _repository = new CurrencyRepository(httpClient, apiConfig);
        }

        [Fact]
        public void CanGetAll() {
            var result = _repository.GetAll();

            Assert.NotNull(result);

            System.Diagnostics.Debug.WriteLine(result);
        }
    }
}