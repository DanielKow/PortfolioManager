using PortfolioManager.Domain.ExchangeRates;

namespace PortfolioManager.Application.Cryptocurrencies;

public interface ICryptoCurrencyExchangeRateService
{
    decimal Get(string currency);
    void Update(ExchangeRate exchangeRate);
    void UpdateMany(IEnumerable<ExchangeRate> exchangeRates);
}