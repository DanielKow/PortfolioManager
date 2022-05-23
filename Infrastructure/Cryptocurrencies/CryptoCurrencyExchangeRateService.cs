using System.Globalization;
using Microsoft.Extensions.Caching.Distributed;
using PortfolioManager.Application.Cryptocurrencies;
using PortfolioManager.Domain.ExchangeRates;

namespace PortfolioManager.Infrastructure.Cryptocurrencies;

public class CryptoCurrencyExchangeRateService : ICryptoCurrencyExchangeRateService
{
    private readonly IDistributedCache _cache;

    public CryptoCurrencyExchangeRateService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public decimal Get(string currency)
    {
        var valueFromCache = _cache.GetString(currency);
        var numericalValue = decimal.Parse(valueFromCache, NumberStyles.Any, CultureInfo.InvariantCulture);
        return numericalValue;
    }

    public void Update(ExchangeRate exchangeRate)
    {
        var stringValue = exchangeRate.Value.ToString(CultureInfo.InvariantCulture);
        _cache.SetString(exchangeRate.Currency, stringValue);
    }

    public void UpdateMany(IEnumerable<ExchangeRate> exchangeRates)
    {
        foreach (var exchangeRate in exchangeRates)
        {
            Update(exchangeRate);
        }
    }
}