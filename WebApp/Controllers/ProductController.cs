using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Helpper;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        ApiConnect apiConnect = new ApiConnect("https://localhost:44307/");
        public async Task<IActionResult> Index()
        {
            List<Product> ProductList = new List<Product>();
            string apiResponse = apiConnect.Get("Products", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                ProductList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
            }
            return View(ProductList);
        }
        public async Task<IActionResult> ViewList()
        {
            List<Product> ProductList = new List<Product>();
            string apiResponse = apiConnect.Get("Products", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                ProductList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
            }
            return View(ProductList);
        }
        public async Task<IActionResult> ViewAddUpdateProduct(int? id)
        {
            Product Product = new Product();
            if (id != null)
            {
                string apiResponse = apiConnect.Get("Products", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    Product = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(Product);
        }
        public JsonResult AddUpdateProduct(Product modelProduct)
        {
            Product Product = new Product();
            string apiResponse = "";
            if (modelProduct.ProductID > 0)
            {
                apiResponse = apiConnect.Put("Products", "", modelProduct.ProductID.ToString(), new Dictionary<string, object> {
                    {"ProductID",modelProduct.ProductID },
                    {"Name",modelProduct.Name },
                    {"Price",modelProduct.Price }
                });
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = Product.ProductID });
                }
            }
            else
            {
                apiResponse = apiConnect.Post("Products", "", new Dictionary<string, object> {
                    {"Name",modelProduct.Name },
                    {"Price",modelProduct.Price }
                });
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    Product = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
                if (Product != null && Product.ProductID != 0)
                {
                    return Json(new { returncode = 0, id = Product.ProductID });
                }
            }

            return Json(new { returncode = -1 });
        }
        public JsonResult DeleteProduct(int id)
        {
            Product Product = new Product();
            string apiResponse = "";
            if (id > 0)
            {
                apiResponse = apiConnect.Delete("Products", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = Product.ProductID });
                }
            }

            return Json(new { returncode = -1 });
        }
    }
}
