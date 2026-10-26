using Microsoft.AspNetCore.Mvc;
using GadgetInventory.Models;
using System.Collections.Generic;

namespace GadgetInventory.Controllers
{
    public class GadgetController : Controller
    {
        private static List<Gadget> _gadgets = new List<Gadget>
        {
            new Gadget { Id = 1, Brand = "Realme", ModelName = "Realme 10 Pro+", Price = 499.99m },
            new Gadget { Id = 2, Brand = "Poco", ModelName = "Poco X5 Pro", Price = 399.99m },
            new Gadget { Id = 3, Brand = "Samsung", ModelName = "Galaxy S23", Price = 849.00m }
        };

        public IActionResult Index()
        {
            return View(_gadgets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gadget newGadget)
        {
            if (!ModelState.IsValid)
            {
                return View(newGadget);
            }

            newGadget.Id = _gadgets.Count + 1;
            _gadgets.Add(newGadget);

            return RedirectToAction("Index");
        }
    }
}