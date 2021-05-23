using Newtonsoft.Json;
using RateChecker.Core;
using RateChecker.Models;
using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Repositories{
    public class ExchangeRateRepository : BaseRepository{
        public ExchangeRateRepository(IHttpClient httpClient, ApiConfiguration apiConfiguration)
            : base(httpClient, apiConfiguration){
        }

        public IEnumerable<ExchangeRate> GetAll(){
            var response = _httpClient.SendGetRequest(_apiConfiguration);
            var result = JsonConvert.DeserializeObject<List<ExchangeRate>>(response);
            return result;
        }
    }
}