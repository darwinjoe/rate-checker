using RateChecker.Services;
using System;
using System.Linq;
using Xunit;

namespace RateCheckerTest
{
    public class WiseServiceTest{
        private readonly WiseService _service;

        public WiseServiceTest() {
            var baseUrl = Environment.GetEnvironmentVariable("apiconfiguration.baseurl.wise");
            var token = Environment.GetEnvironmentVariable("apiconfiguration.token.wise");

            _service = new WiseService(baseUrl, token);
        }

        [Fact]
        public void CanGetRate(){
            var result = _service.GetExchangeRate("AUD", "USD");

            Assert.NotNull(result);
            Assert.Equal("AUD", result.Source.Code);
            Assert.Equal("USD", result.Target.Code);
            Assert.True(result.Rate > 0, "Expected rate to be greater than 0");
        }

        [Fact]
        public void CanGetAllRates(){
            var result = _service.GetAllExchangeRates("AUD");

            Assert.NotNull(result);
            Assert.True(result.ToList().Count > 0, "Expected rates count to be greater than 0");
        }
    }
}