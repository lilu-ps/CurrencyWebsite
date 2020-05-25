using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                uniqueCurrencies.Add(curr.fromCurrency);
            }
            ViewBag.operations = new SelectList(uniqueCurrencies);

            return View(cm);
        }


        [HttpPost]
        public IActionResult convert(CalculatorModel calculatorModel)
        {
            if (ModelState.IsValid)
            {
                calculatorModel.CreateDatetime = DateTime.Now;
                _calRep.convert(calculatorModel);
                return RedirectToAction("Index", "Calculator");
            }
            return View();
        }
    }
}