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

    public async Task<decimal> Get(string currency)
    {
        var valueFromCache = await _cache.GetStringAsync(currency);
        var numericalValue = decimal.Parse(valueFromCache, NumberStyles.Any, CultureInfo.InvariantCulture);
        return numericalValue;
    }

    public async Task Update(ExchangeRate exchangeRate)
    {
        var stringValue = exchangeRate.Value.ToString(CultureInfo.InvariantCulture);
        await _cache.SetStringAsync(exchangeRate.Currency, stringValue);
    }

    public async Task UpdateMany(IEnumerable<ExchangeRate> exchangeRates)
    {
        foreach (var exchangeRate in exchangeRates)
        {
            await Update(exchangeRate);
        }
    }
}