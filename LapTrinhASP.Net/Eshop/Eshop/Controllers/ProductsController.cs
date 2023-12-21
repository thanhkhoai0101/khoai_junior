using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eshop.Controllers
{
    public class ProductsController : Controller
    {
        private EshopContext _context;
        // GET: /<controller>/
        public ProductsController(EshopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

       
            return View(products);

        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

