using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Helpper;
using Newtonsoft.Json;
namespace WebApp.Controllers
{
    public class ShopProductController : Controller
    {
        ApiConnect apiConnect = new ApiConnect("https://localhost:44307/");
        public async Task<IActionResult> Index(int? id)
        {

            //get detail shop
            Shop shop = new Shop();
            string apiResponseShop = apiConnect.Get("Shops", "", id.ToString());
            if (!string.IsNullOrEmpty(apiResponseShop))
            {
                shop = JsonConvert.DeserializeObject<Shop>(apiResponseShop);
            }
            ViewBag.SchopDetail = shop;
            List<Product> ProductList = new List<Product>();
            string apiResponse = apiConnect.Get("ShopProducts", "", id.ToString());
            if (!string.IsNullOrEmpty(apiResponse))
            {
                ProductList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
            }
            return View(ProductList);
        }
        public async Task<IActionResult> ViewList(int? id)
        {
            List<Product> ProductList = new List<Product>();
            string apiResponse = apiConnect.Get("ShopProducts", "", id.ToString());
            if (!string.IsNullOrEmpty(apiResponse))
            {
                ProductList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
            }
            return View(ProductList);
        }
        public async Task<IActionResult> ViewAddProduct()
        {
            List<Product> products = new List<Product>();
            string apiResponse = apiConnect.Get("Products", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
            }
            return View(products);
        }
        public JsonResult AddProduct(ShopProduct modelShopProduct)
        {
            string apiResponse = "";
            apiResponse = apiConnect.Post("ShopProducts", "", new Dictionary<string, object> {
                    {"ShopID",modelShopProduct.ShopID },
                    {"ProductID",modelShopProduct.ProductID }
                });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                return Json(new { returncode = 0, id = modelShopProduct.ShopProductID });
            }

            return Json(new { returncode = -1 });
        }
        public JsonResult DeleteProduct(int id)
        {
            ShopProduct shopProduct = new ShopProduct();
            string apiResponse = "";
            if (id > 0)
            {
                apiResponse = apiConnect.Delete("ShopProducts", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = id });
                }
            }

            return Json(new { returncode = -1 });
        }
    }
}
