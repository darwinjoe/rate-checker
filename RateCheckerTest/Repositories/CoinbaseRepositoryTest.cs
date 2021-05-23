using RateChecker.Services;
using Xunit;

namespace RateCheckerTest{
    public class CoinbaseRepositoryTest{
        private readonly CoinbaseService _repository;

        public CoinbaseRepositoryTest() {
            _repository = new CoinbaseService("https://api.coinbase.com/v2");
        }

        [Fact]
        public void CanGetAllCurrencies() {
            var result = _repository.GetAllCurrencies();

            Assert.NotNull(result);
        }

        [Fact]
        public void CanGetAllRates(){
            var result = _repository.GetAllExchangeRates("AUD");

            Assert.NotNull(result);
        }
    }
}