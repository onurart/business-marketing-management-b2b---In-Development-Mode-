using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace TredeWeb.Controllers
{
    public class FnBarterFicheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
