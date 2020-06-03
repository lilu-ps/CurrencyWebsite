using CurrencyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CurrencyApp.Controllers
{
    public class ReportController : Controller
    {
        private ICalculatorRepository _calRep;
        private ICurrencyRepository _currRep;

        public ReportController(ICalculatorRepository calRep, ICurrencyRepository currRep)
        {
            _calRep = calRep;
            _currRep = currRep;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult time()
        {
            //CurrencyModel cm = new CurrencyModel();
            //List<RegisterModel> registeredCurrencies = _regRep.GetAllRegisteredCurrencies().ToList().OrderBy(rm => rm.OrderNum).ToList();

            //List<string> uniqueCurrencies = new List<string>();
            //foreach (RegisterModel rm in registeredCurrencies)
            //{
            //    uniqueCurrencies.Add(rm.CurrencyCode);
            //}
            //ViewBag.registeredList = new SelectList(uniqueCurrencies);
            return View();
        }


        //[HttpPost]
        //public IActionResult time()
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    CurrencyModel cm = _currRep.create(currencyModel);
        //    //    return RedirectToAction("Index", "Currency");
        //    //}
        //    return View();
        //}

        [HttpGet]
        public IActionResult back()
        {
            return RedirectToAction("Index", "Report");
        }


        [HttpGet]
        public IActionResult suspicious()
        {
            List<CalculatorModel> transactions = _calRep.getAllOperations().ToList().OrderByDescending(cm => cm.sell * _currRep.getCurrByName(cm.fromCurrency).BuyRate).ToList();

            List<CalculatorModel> suspiciousT = new List<CalculatorModel>();
            int ind = 0;
            foreach (CalculatorModel cur in transactions)
            {
                if (ind >= 5) break;
                suspiciousT.Add(cur);
                ind++;
            }
            //ViewBag.suspiciousList = new SelectList(suspiciousT);
            return View(suspiciousT);
        }
    }
}