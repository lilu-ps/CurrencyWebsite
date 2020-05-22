using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public interface ICurrencyRepository
    {
        CurrencyModel getCurr(int Id);
        IEnumerable<CurrencyModel> getAllCurrencies();
        CurrencyModel create(CurrencyModel currencyModel);
        CurrencyModel update(CurrencyModel currencyModel);
        CurrencyModel delete(int Id);

    }
}
