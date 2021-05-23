using Newtonsoft.Json;
using RateChecker.Core;
using RateChecker.Models;
using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Repositories{
    public class BaseRepository{
        protected readonly IHttpClient _httpClient;
        protected readonly ApiConfiguration _apiConfiguration;

        public BaseRepository(IHttpClient httpClient, ApiConfiguration apiConfiguration) {
            _httpClient = httpClient;
            _apiConfiguration = apiConfiguration;
        }
    }
}