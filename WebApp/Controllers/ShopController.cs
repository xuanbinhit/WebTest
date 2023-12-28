using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Helpper;
using Newtonsoft.Json;
namespace WebApp.Controllers
{
    public class ShopController : Controller
    {
        ApiConnect apiConnect = new ApiConnect("https://localhost:44307/");
        public async Task<IActionResult> Index()
        {
            List<Shop> ShopList = new List<Shop>();
            string apiResponse = apiConnect.Get("Shops", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                ShopList = JsonConvert.DeserializeObject<List<Shop>>(apiResponse);
            }
            return View(ShopList);
        }
        public async Task<IActionResult> ViewList()
        {
            List<Shop> ShopList = new List<Shop>();
            string apiResponse = apiConnect.Get("Shops", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                ShopList = JsonConvert.DeserializeObject<List<Shop>>(apiResponse);
            }
            return View(ShopList);
        }
        public async Task<IActionResult> ViewAddUpdateShop(int? id)
        {
            Shop Shop = new Shop();
            if (id != null)
            {
                string apiResponse = apiConnect.Get("Shops", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    Shop = JsonConvert.DeserializeObject<Shop>(apiResponse);
                }
            }
            return View(Shop);
        }
        public JsonResult AddUpdateShop(Shop modelShop)
        {
            Shop Shop = new Shop();
            string apiResponse = "";
            if (modelShop.ShopID > 0)
            {
                apiResponse = apiConnect.Put("Shops", "", modelShop.ShopID.ToString(), new Dictionary<string, object> {
                    {"ShopID",modelShop.ShopID },
                    {"Name",modelShop.Name },
                    {"Location",modelShop.Location }
                });
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = Shop.ShopID });
                }
            }
            else
            {
                apiResponse = apiConnect.Post("Shops", "", new Dictionary<string, object> {
                    {"Name",modelShop.Name },
                    {"Location",modelShop.Location }
                });
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    Shop = JsonConvert.DeserializeObject<Shop>(apiResponse);
                }
                if (Shop != null && Shop.ShopID != 0)
                {
                    return Json(new { returncode = 0, id = Shop.ShopID });
                }
            }

            return Json(new { returncode = -1 });
        }
        public JsonResult DeleteShop(int id)
        {
            Shop Shop = new Shop();
            string apiResponse = "";
            if (id > 0)
            {
                apiResponse = apiConnect.Delete("Shops", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = Shop.ShopID });
                }
            }

            return Json(new { returncode = -1 });
        }
    }
}
