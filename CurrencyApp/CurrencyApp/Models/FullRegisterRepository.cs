using System.Collections.Generic;
using System.Linq;

namespace CurrencyApp.Models
{
    public class FullRegisterRepository : IRegisterRepository
    {

        private readonly CurrencyContext _cc;

        public FullRegisterRepository(CurrencyContext cc)
        {
            _cc = cc;
        }

        public IEnumerable<RegisterModel> GetAllRegisteredCurrencies()
        {
            return _cc.RegisteredList;
        }

        public RegisterModel add(RegisterModel registerModel)
        {
            _cc.RegisteredList.Add(registerModel);
            _cc.SaveChanges();

            return registerModel;
        }

        public RegisterModel GetRegCurr(int Id)
        {
           return _cc.RegisteredList.FirstOrDefault(e => e.Id == Id);
        }

    }
}
