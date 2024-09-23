using Microsoft.AspNetCore.Mvc;
using AdonetCrud.Models;
using AdonetCrud.BusinesLogicLayer;

namespace AdonetCrud.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ProductBusinessLayer nextLayer = new ProductBusinessLayer();
            bool result = nextLayer.Create(product);
            
            if (result == true)
            {
              return RedirectToAction("Products", "Product");  //Name of Action , Name of Controller
            }

            return BadRequest(new { Message = "Could not insert the product" });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductBusinessLayer nextLayer = new ProductBusinessLayer();
           Product result = nextLayer.GetProductById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult Update(Product product)
        {
            ProductBusinessLayer nextLayer = new ProductBusinessLayer();

            bool result = nextLayer.Update(product);
            if (result == true)
            {
                return RedirectToAction("Products", "Product");
            }
            return BadRequest(new { Message = "Failed to Update the Product" });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductBusinessLayer nextLayer = new ProductBusinessLayer();
            bool result = nextLayer.DeleteById(id);
            if (result == true)
            {
                return RedirectToAction("Products","Product");  //Name of actions, name of controller
            }

            return BadRequest(new { Message = "Could not Delete"});
        }
        [HttpGet]
        public IActionResult Products()
        {
            ProductBusinessLayer nextLayer = new ProductBusinessLayer();
            List<Product> products = nextLayer.GetProducts();
            return View(products);

        }
    }
}
