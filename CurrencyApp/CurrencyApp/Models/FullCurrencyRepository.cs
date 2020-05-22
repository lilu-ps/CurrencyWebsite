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
            _cc.currencies.Add(currencyModel);
            _cc.SaveChanges();
            return currencyModel;
        }

        public CurrencyModel delete(int Id)
        {
            CurrencyModel cm = _cc.currencies.FirstOrDefault(e => e.Id == Id);
            cm.Removed = 1;
            if (cm != null)
            {
                _cc.currencies.Remove(cm);
                _cc.SaveChanges();
            }
            return cm;
        }

        public IEnumerable<CurrencyModel> getAllCurrencies()
        {
            return _cc.currencies;
        }

        public CurrencyModel getCurr(int Id)
        {
            return _cc.currencies.Find(Id);//FirstOrDefault(e => e.Id == Id);
        }

        public CurrencyModel update(CurrencyModel currencyModel)
        {
            var cm = _cc.currencies.Attach(currencyModel);
            cm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _cc.SaveChanges();
           
            return currencyModel;
        }
    }
}
