using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Helpper;
namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        ApiConnect apiConnect = new ApiConnect("https://localhost:44307/");
        public async Task<IActionResult> Index()
        {
            List<Customer> customerList = new List<Customer>();
            string apiResponse = apiConnect.Get("Customers","",new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                customerList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
            }
            return View(customerList);
        }
        public async Task<IActionResult> ViewList()
        {
            List<Customer> customerList = new List<Customer>();
            string apiResponse = apiConnect.Get("Customers", "", new Dictionary<string, object> { });
            if (!string.IsNullOrEmpty(apiResponse))
            {
                customerList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
            }
            return View(customerList);
        }
        public async Task<IActionResult> ViewAddUpdateCustomer(int? id)
        {
            Customer customer = new Customer();
            if (id != null)
            {
                string apiResponse = apiConnect.Get("Customers", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return View(customer);
        }
        public JsonResult AddUpdateCustomer(Customer modelCustomer)
        {
            Customer customer = new Customer();
            string apiResponse = "";
            if (modelCustomer.CustomerID > 0)
            {
                apiResponse=apiConnect.Put("Customers", "",modelCustomer.CustomerID.ToString(), new Dictionary<string, object> {
                    {"CustomerID",modelCustomer.CustomerID },
                    {"Name",modelCustomer.Name },
                    {"DOB",modelCustomer.DOB },
                    {"Email",modelCustomer.Email },
                });
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = customer.CustomerID });
                }
            }
            else
            {
                apiResponse=apiConnect.Post("Customers", "", new Dictionary<string, object> {
                    {"Name",modelCustomer.Name },
                    {"DOB",modelCustomer.DOB },
                    {"Email",modelCustomer.Email },
                });
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
                if (customer != null && customer.CustomerID != 0)
                {
                    return Json(new { returncode = 0, id = customer.CustomerID });
                }
            }
            
            return Json(new {returncode=-1});
        }
        public JsonResult DeleteCustomer(int id)
        {
            Customer customer = new Customer();
            string apiResponse = "";
            if (id > 0)
            {
                apiResponse = apiConnect.Delete("Customers", "", id.ToString());
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    return Json(new { returncode = 0, id = customer.CustomerID });
                }
            }

            return Json(new { returncode = -1 });
        }
    }
}
