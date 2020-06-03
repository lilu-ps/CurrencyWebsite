using CurrencyApp.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyApp.Controllers
{
    public class RegisterController : Controller
    {

        private IRegisterRepository _regRep;

        public RegisterController(IRegisterRepository regRep)
        {
            _regRep = regRep;
        }

        public IActionResult Index()
        {
            List<RegisterModel> registeredCurrencies = _regRep.GetAllRegisteredCurrencies().ToList().OrderBy(rm=> rm.OrderNum).ToList();
            return View(registeredCurrencies);
        }

        [HttpGet]
        public IActionResult add()
        {
            RegisterModel rm = new RegisterModel();
            return View(rm);
        }


        [HttpPost]
        public IActionResult add(RegisterModel registerModel)
        {

            if (ModelState.IsValid)
            {
                if (_regRep.GetAllRegisteredCurrencies().FirstOrDefault(e => e.CurrencyCode == registerModel.CurrencyCode) != null)
                {
                    ViewData["Exists"] = "Currency Already Exists";
                    RegisterModel newrm = new RegisterModel();
                    return View(newrm);
                }

                RegisterModel rm = _regRep.add(registerModel);
                return RedirectToAction("Index", "Register");
            }
            return View();
        }

    }
}