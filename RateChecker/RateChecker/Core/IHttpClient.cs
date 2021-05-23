using RateChecker.Models.CurrencyApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Core{
    public interface IHttpClient{
        string SendGetRequest(ApiConfiguration apiConfiguration);

        string SendPostRequest(ApiConfiguration apiConfiguration, string body);
    }
}