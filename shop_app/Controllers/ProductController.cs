using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop_app.Models;
using shop_app.Services;

namespace shop_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceProduct _serviceProduct;
        public ProductController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var products = await _serviceProduct.ReadAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _serviceProduct.GetByIdAsync(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description")] Product product)
        {
            if(ModelState.IsValid)
            {
                _ = await _serviceProduct.CreateAsync(product);
                return RedirectToAction(nameof(Read));
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Update() => View();
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,Name,Price,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _ = await _serviceProduct.UpdateAsync(id, product);
                return RedirectToAction(nameof(Read));
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete() => View();
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _ = await _serviceProduct.DeleteAsync(id);
            return RedirectToAction(nameof(Read));
        }
    }
}
