using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Helpper;
using Newtonsoft.Json;
namespace WebApp.Controllers
{
    public class ShoppingController : Controller
    {
        ApiConnect apiConnect = new ApiConnect("https://localhost:44307/");
        public async Task<IActionResult> Index()
        {
            List<CustomerBuy> customerBuyList = new List<CustomerBuy>();
            string apiResponse = apiConnect.Get("CustomerBuys", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                customerBuyList = JsonConvert.DeserializeObject<List<CustomerBuy>>(apiResponse);
            }
            return View(customerBuyList);
        }
        public async Task<IActionResult> ViewList()
        {
            List<CustomerBuy> customerBuyList = new List<CustomerBuy>();
            string apiResponse = apiConnect.Get("CustomerBuys", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                customerBuyList = JsonConvert.DeserializeObject<List<CustomerBuy>>(apiResponse);
            }
            return View(customerBuyList);
        }
        public async Task<IActionResult> ViewAddProduct()
        {
            List<Customer> customerList = new List<Customer>();
            string apiResponse_Customer = apiConnect.Get("Customers", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse_Customer))
            {
                customerList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse_Customer);
            }
            ViewBag.Customer = customerList;

            List<CustomerBuy> customerBuyList = new List<CustomerBuy>();
            string apiResponse = apiConnect.Get("CustomerBuys", "Product", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                customerBuyList = JsonConvert.DeserializeObject<List<CustomerBuy>>(apiResponse);
            }
            return View(customerBuyList);
        }
        public JsonResult AddProduct(CustomerBuy modelProduct)
        {
            CustomerBuy customerBuy = new CustomerBuy();
            string apiResponse = "";
            apiResponse = apiConnect.Post("CustomerBuys", "", new Dictionary<string, object> {
                    {"ShopProductID",modelProduct.ShopProductID },
                    {"CustomerID",modelProduct.CustomerID }
                });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                return Json(new { returncode = 0, id = customerBuy.CustomerBuyID });
            }

            return Json(new { returncode = -1 });
        }
    }
}
