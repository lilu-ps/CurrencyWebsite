using System.Collections.Generic;

namespace CurrencyApp.Models
{
    public interface ICalculatorRepository
    {
        CalculatorModel getCurr(int Id);

        IEnumerable<CalculatorModel> getAllOperations();
        CalculatorModel convert(CalculatorModel currencyModel);



    }
}

