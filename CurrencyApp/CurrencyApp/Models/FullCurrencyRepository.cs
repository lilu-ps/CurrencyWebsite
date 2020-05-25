using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class FullCurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext _cc;
        public FullCurrencyRepository(CurrencyContext cc)
        {
            _cc = cc;
        }

        public CurrencyModel create(CurrencyModel currencyModel)
        {
            _cc.Currencies.Add(currencyModel);
            _cc.SaveChanges();
            return currencyModel;
        }

        public CurrencyModel delete(int Id)
        {
            CurrencyModel cm = _cc.Currencies.FirstOrDefault(e => e.Id == Id);
            cm.Removed = 1;
            if (cm != null)
            {
                _cc.Currencies.Remove(cm);
                _cc.SaveChanges();
            }
            return cm;
        }

        public IEnumerable<CurrencyModel> getAllCurrencies()
        {
            return _cc.Currencies;
        }

        public CurrencyModel getCurr(int Id)
        {
            return _cc.Currencies.FirstOrDefault(e => e.Id == Id);
        }

        public CurrencyModel update(CurrencyModel currencyModel)
        {
            var cm = _cc.Currencies.Attach(currencyModel);
            cm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _cc.SaveChanges();
           
            return currencyModel;
        }
    }
}
