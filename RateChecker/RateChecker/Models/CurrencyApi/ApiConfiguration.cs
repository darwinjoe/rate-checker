using System;
using System.Collections.Generic;
using System.Text;

namespace RateChecker.Models.CurrencyApi{
    public class ApiConfiguration{
        public string BaseUrl { get; set; }
        public string SuffixUrl { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public String getUrl() {
            return BaseUrl + SuffixUrl;
        }
    }
}