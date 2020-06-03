using System;
using System.Collections.Generic;
using System.Globalization;
using CurrencyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyApp.Controllers
{
    public class CalculatorController : Controller
    {

        private ICalculatorRepository _calRep;
        private ICurrencyRepository _currRep;

        public CalculatorController(ICalculatorRepository calRep, ICurrencyRepository currRep)
        {
            _calRep = calRep;
            _currRep = currRep;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var model = _calRep.getAllOperations();
            return View(model); 
        }

        [HttpGet]
        public IActionResult convert()
        {
            CalculatorModel cm = new CalculatorModel();

            HashSet<String> uniqueCurrencies = new HashSet<String>();
            foreach (CurrencyModel curr in _currRep.getAllCurrencies())
            {
                uniqueCurrencies.Add(curr.Currency);
            }
            ViewBag.operations = new SelectList(uniqueCurrencies);

            return View(cm);
        }


        [HttpPost]
        public IActionResult convert(string fromCurrency, string toCurrency, string sell, string buy, string comment)//CalculatorModel calculatorModel)
        {
            if (ModelState.IsValid)
            {
                CalculatorModel calculatorModel = new CalculatorModel();
                calculatorModel.fromCurrency = fromCurrency;
                calculatorModel.toCurrency = toCurrency;
                calculatorModel.sell = decimal.Parse(sell, CultureInfo.InvariantCulture);
                calculatorModel.buy = decimal.Parse(buy, CultureInfo.InvariantCulture);
                calculatorModel.comment = comment;


                calculatorModel.CreateDatetime = DateTime.Now;


                _calRep.convert(calculatorModel);


                return RedirectToAction("Index", "Calculator");
            }
            return View();
        }

        [HttpPost]
        public JsonResult getCurrencyRate(string fromCurrency, string toCurrency)
        {
            
            CurrencyModel from =  _currRep.getCurrByName(fromCurrency);
            CurrencyModel to = _currRep.getCurrByName(toCurrency);
            decimal result = 0;
            if (from.SellRate != 0)
            {
                result = 1 / to.SellRate * from.BuyRate;
            }


            return Json(result) ;
        }

        [HttpPost]
        public JsonResult getRateToGel(string fromCurrency)
        {
            return Json(new { rate = _currRep.getCurrByName(fromCurrency).BuyRate });
        }
    }
}