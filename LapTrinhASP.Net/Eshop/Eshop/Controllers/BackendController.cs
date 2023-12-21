using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eshop.Controllers
{
    public class BackendController : Controller
    {
        EshopContext _context;

        // GET: /<controller>/
        public BackendController(EshopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
      
    }
}

