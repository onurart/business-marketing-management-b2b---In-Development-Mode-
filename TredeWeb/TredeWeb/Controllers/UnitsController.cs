﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TredeWeb.Controllers
{
    public class UnitsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
