using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public interface ICalculatorRepository
    {
        CalculatorModel getCurr(int Id);
        IEnumerable<CalculatorModel> getAllOperations();
        CalculatorModel convert(CalculatorModel currencyModel);



    }
}

