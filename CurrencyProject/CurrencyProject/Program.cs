using System;

namespace CurrencyProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            for (int i = 0; i < 19; i++)
            {
                var curContext = new CurrencyContext();
                Random random = new Random();
                var randCur = random.NextDouble() * 3 + 1;
                var currency = new Currency
                {
                    CurrencyValue = (decimal)randCur,
                    fromCurrency = "USD",
                    toCurrency = "GEL",
                    Datetime = Convert.ToDateTime($"2020/05/{i + 1}")
                };
                curContext.Add(currency);
                curContext.SaveChanges();
            }
        }
    }
}
