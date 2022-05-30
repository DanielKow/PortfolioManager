using PortfolioManager.Domain.ExchangeRates;

namespace PortfolioManager.Application.Cryptocurrencies;

public interface ICryptocurrencyExchangeRateRepository
{
    Task<ExchangeRate> Get(string currency);
}