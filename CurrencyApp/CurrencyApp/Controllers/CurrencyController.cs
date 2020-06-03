using CurrencyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CurrencyApp.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyRepository _currRep;
        private IRegisterRepository _regRep;

        public CurrencyController(ICurrencyRepository currRep, IRegisterRepository regRep)
        {
            _currRep = currRep;
            _regRep = regRep;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _currRep.getAllCurrencies();
            return View(model);
        }



        [HttpGet]
        public IActionResult create()
        {
            CurrencyModel cm = new CurrencyModel();
            addDropDownList();

            return View(cm);
        }

        private void addDropDownList()
        {
            List<RegisterModel> registeredCurrencies = _regRep.GetAllRegisteredCurrencies().ToList().OrderBy(rm => rm.OrderNum).ToList();

            List<string> uniqueCurrencies = new List<string>();
            foreach (RegisterModel rm in registeredCurrencies)
            {
                uniqueCurrencies.Add(rm.CurrencyCode);
            }
            ViewBag.registeredList = new SelectList(uniqueCurrencies);

        }


        [HttpPost]
        public IActionResult create(CurrencyModel currencyModel)
        {
            if (ModelState.IsValid)
            {
                if (_currRep.getCurrByName(currencyModel.Currency) != null)
                {
                    ViewData["Exists"] = "Course Already Exists";
                    CurrencyModel newcm = new CurrencyModel();
                    addDropDownList();

                    return View(newcm);
                }
                CurrencyModel cm = _currRep.create(currencyModel);
                return RedirectToAction("Index", "Currency");
            }
            return View();
        }

        [HttpGet]
        public IActionResult update(int Id)
        {
            CurrencyModel cm = _currRep.getCurr(Id);
            return View(cm);
        }

        [HttpPost]
        public IActionResult update(CurrencyModel currencyModel)
        {
            if (ModelState.IsValid)
            {
                _currRep.update(currencyModel);
                return RedirectToAction("Index", "Currency");
            }
            return View();

        }

        [HttpGet]
        public IActionResult delete(int id)
        {
            _currRep.delete(id);
            return RedirectToAction("Index", "Currency");
        }
    }


}