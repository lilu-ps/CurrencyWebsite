using System.Collections.Generic;


namespace CurrencyApp.Models
{
    public interface IRegisterRepository
    {
        RegisterModel GetRegCurr(int Id);

        IEnumerable<RegisterModel> GetAllRegisteredCurrencies();

        RegisterModel add(RegisterModel registerModel);
    }
}
