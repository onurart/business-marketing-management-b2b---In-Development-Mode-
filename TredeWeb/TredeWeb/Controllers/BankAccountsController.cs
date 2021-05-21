using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace TredeWeb.Controllers
{
    public class BankAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
