using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace crud2.Controllers
{
    public class CustomerController : Controller
    {
        
        

        public IActionResult Index()
        {
         
            return View();
        }
    }
}