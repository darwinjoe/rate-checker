using Newtonsoft.Json;
using RateChecker.Core;
using RateChecker.Models;
using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Repositories{
    public class CurrencyRepository : BaseRepository{
        public CurrencyRepository(IHttpClient httpClient, ApiConfiguration apiConfiguration) 
            : base(httpClient, apiConfiguration){   
        }

        public IEnumerable<Currency> GetAll(){
            var response = _httpClient.SendGetRequest(_apiConfiguration);
            var result = JsonConvert.DeserializeObject<List<Currency>>(response);
            return result;
        }
    }
}