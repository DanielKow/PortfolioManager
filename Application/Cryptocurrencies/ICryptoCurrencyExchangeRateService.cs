using PortfolioManager.Domain.ExchangeRates;

namespace PortfolioManager.Application.Cryptocurrencies;

public interface ICryptoCurrencyExchangeRateService
{
    Task<decimal> Get(string currency);
    Task Update(ExchangeRate exchangeRate);
    Task UpdateMany(IEnumerable<ExchangeRate> exchangeRates);
}