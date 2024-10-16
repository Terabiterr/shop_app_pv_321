using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
