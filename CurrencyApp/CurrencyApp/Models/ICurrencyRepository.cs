using System.Collections.Generic;

namespace CurrencyApp.Models
{
    public interface ICurrencyRepository
    {
        CurrencyModel getCurr(int Id);

        CurrencyModel getCurrByName(string Currency);

        IEnumerable<CurrencyModel> getAllCurrencies();
        CurrencyModel create(CurrencyModel currencyModel);
        CurrencyModel update(CurrencyModel currencyModel);
        CurrencyModel delete(int Id);

    }
}
