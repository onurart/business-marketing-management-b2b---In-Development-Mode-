using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TredeWeb.Controllers
{
    public class UserToRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
