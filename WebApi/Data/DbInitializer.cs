using WebApi.Models;
using System;
using System.Linq;
namespace WebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataTestContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
            new Customer{CustomerID=1, Name="Carson Alexander 01",DOB=DateTime.Parse("2005-09-01"),Email="customer.01@gmail.com"},
            new Customer{CustomerID=2,Name="Carson Alexander 02",DOB=DateTime.Parse("2005-09-02"),Email="customer.02@gmail.com"},
            new Customer{CustomerID=3,Name="Carson Alexander 03",DOB=DateTime.Parse("2005-09-03"),Email="customer.03@gmail.com"},
            new Customer{CustomerID=4,Name="Carson Alexander 04",DOB=DateTime.Parse("2005-09-04"),Email="customer.04@gmail.com"},
            new Customer{CustomerID=5,Name="Carson Alexander 05",DOB=DateTime.Parse("2005-09-05"),Email="customer.05@gmail.com"},
            new Customer{CustomerID=6,Name="Carson Alexander 06",DOB=DateTime.Parse("2005-09-06"),Email="customer.06@gmail.com"},
            new Customer{CustomerID=7,Name="Carson Alexander 07",DOB=DateTime.Parse("2005-09-07"),Email="customer.07@gmail.com"},
            new Customer{CustomerID=8,Name="Carson Alexander 08",DOB=DateTime.Parse("2005-09-08"),Email="customer.08@gmail.com"},
            new Customer{CustomerID=9,Name="Carson Alexander 09",DOB=DateTime.Parse("2005-09-09"),Email="customer.09@gmail.com"},
            new Customer{CustomerID=10,Name="Carson Alexander 10",DOB=DateTime.Parse("2005-09-10"),Email="customer.10@gmail.com"},
            new Customer{CustomerID=11,Name="Carson Alexander 11",DOB=DateTime.Parse("2005-09-11"),Email="customer.11@gmail.com"},
            new Customer{CustomerID=12,Name="Carson Alexander 12",DOB=DateTime.Parse("2005-09-12"),Email="customer.12@gmail.com"},
            new Customer{CustomerID=13,Name="Carson Alexander 13",DOB=DateTime.Parse("2005-09-13"),Email="customer.13@gmail.com"},
            new Customer{CustomerID=14,Name="Carson Alexander 14",DOB=DateTime.Parse("2005-09-14"),Email="customer.14@gmail.com"},
            new Customer{CustomerID=15,Name="Carson Alexander 15",DOB=DateTime.Parse("2005-09-15"),Email="customer.15@gmail.com"},
            new Customer{CustomerID=16,Name="Carson Alexander 16",DOB=DateTime.Parse("2005-09-16"),Email="customer.16@gmail.com"},
            new Customer{CustomerID=17,Name="Carson Alexander 17",DOB=DateTime.Parse("2005-09-17"),Email="customer.17@gmail.com"},
            new Customer{CustomerID=18,Name="Carson Alexander 18",DOB=DateTime.Parse("2005-09-18"),Email="customer.18@gmail.com"},
            new Customer{CustomerID=19,Name="Carson Alexander 19",DOB=DateTime.Parse("2005-09-19"),Email="customer.19@gmail.com"},
            new Customer{CustomerID=20,Name="Carson Alexander 20",DOB=DateTime.Parse("2005-09-20"),Email="customer.20@gmail.com"},
            new Customer{CustomerID=21,Name="Carson Alexander 21",DOB=DateTime.Parse("2005-09-21"),Email="customer.21@gmail.com"},
            new Customer{CustomerID=22,Name="Carson Alexander 22",DOB=DateTime.Parse("2005-09-22"),Email="customer.22@gmail.com"},
            new Customer{CustomerID=23,Name="Carson Alexander 23",DOB=DateTime.Parse("2005-09-23"),Email="customer.23@gmail.com"},
            new Customer{CustomerID=24,Name="Carson Alexander 24",DOB=DateTime.Parse("2005-09-24"),Email="customer.24@gmail.com"},
            new Customer{CustomerID=25,Name="Carson Alexander 25",DOB=DateTime.Parse("2005-09-25"),Email="customer.25@gmail.com"},
            new Customer{CustomerID=26,Name="Carson Alexander 26",DOB=DateTime.Parse("2005-09-26"),Email="customer.26@gmail.com"},
            new Customer{CustomerID=27,Name="Carson Alexander 27",DOB=DateTime.Parse("2005-09-27"),Email="customer.27@gmail.com"},
            new Customer{CustomerID=28,Name="Carson Alexander 28",DOB=DateTime.Parse("2005-09-28"),Email="customer.28@gmail.com"},
            new Customer{CustomerID=29,Name="Carson Alexander 29",DOB=DateTime.Parse("2005-09-29"),Email="customer.29@gmail.com"},
            new Customer{CustomerID=30,Name="Carson Alexander 30",DOB=DateTime.Parse("2005-09-30"),Email="customer.30@gmail.com"}
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var shops = new Shop[]
            {
            new Shop{ShopID=1,Name="Shop 1",Location="Location 1"},
            new Shop{ShopID=2,Name="Shop 2",Location="Location 2"},
            new Shop{ShopID=3,Name="Shop 3",Location="Location 3"}
            };
            foreach (Shop s in shops)
            {
                context.Shops.Add(s);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{ProductID=1,Name="ProductID 1",Price=1},
            new Product{ProductID=2,Name="ProductID 2",Price=2},
            new Product{ProductID=3,Name="ProductID 3",Price=3},
            new Product{ProductID=4,Name="ProductID 4",Price=4},
            new Product{ProductID=5,Name="ProductID 5",Price=5},
            new Product{ProductID=6,Name="ProductID 6",Price=6},
            new Product{ProductID=7,Name="ProductID 7",Price=7},
            new Product{ProductID=8,Name="ProductID 8",Price=8},
            new Product{ProductID=9,Name="ProductID 9",Price=9},
            new Product{ProductID=10,Name="ProductID 10",Price=10},
            new Product{ProductID=11,Name="ProductID 11",Price=11},
            new Product{ProductID=12,Name="ProductID 12",Price=12},
            new Product{ProductID=13,Name="ProductID 13",Price=13},
            new Product{ProductID=14,Name="ProductID 14",Price=14},
            new Product{ProductID=15,Name="ProductID 15",Price=15},
            new Product{ProductID=16,Name="ProductID 16",Price=16},
            new Product{ProductID=17,Name="ProductID 17",Price=17},
            new Product{ProductID=18,Name="ProductID 18",Price=18},
            new Product{ProductID=19,Name="ProductID 19",Price=19},
            new Product{ProductID=20,Name="ProductID 20",Price=20},
            new Product{ProductID=21,Name="ProductID 21",Price=10},
            new Product{ProductID=22,Name="ProductID 22",Price=10},
            new Product{ProductID=23,Name="ProductID 23",Price=10},
            new Product{ProductID=24,Name="ProductID 24",Price=10},
            new Product{ProductID=25,Name="ProductID 25",Price=10},
            new Product{ProductID=26,Name="ProductID 26",Price=10},
            new Product{ProductID=27,Name="ProductID 27",Price=10},
            new Product{ProductID=28,Name="ProductID 28",Price=10},
            new Product{ProductID=29,Name="ProductID 29",Price=10},
            new Product{ProductID=30,Name="ProductID 30",Price=10},
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();


            var shopproducts = new ShopProduct[]
          {
            new ShopProduct{ShopProductID=1,ShopID=1,ProductID=1},
            new ShopProduct{ShopProductID=2,ShopID=1,ProductID=2},
            new ShopProduct{ShopProductID=3,ShopID=1,ProductID=3},
            new ShopProduct{ShopProductID=4,ShopID=2,ProductID=4},
            new ShopProduct{ShopProductID=5,ShopID=2,ProductID=5},
            new ShopProduct{ShopProductID=6,ShopID=2,ProductID=6},
            new ShopProduct{ShopProductID=7,ShopID=3,ProductID=4},
            new ShopProduct{ShopProductID=8,ShopID=3,ProductID=5},
            new ShopProduct{ShopProductID=9,ShopID=3,ProductID=6}
          };
            foreach (ShopProduct s in shopproducts)
            {
                context.ShopProducts.Add(s);
            }
            context.SaveChanges();

            var customerbuys = new CustomerBuy[]
          {
            new CustomerBuy{CustomerBuyID=1,CustomerID=1,ShopProductID=1},
            new CustomerBuy{CustomerBuyID=2,CustomerID=1,ShopProductID=2},
            new CustomerBuy{CustomerBuyID=3,CustomerID=1,ShopProductID=3},
            new CustomerBuy{CustomerBuyID=4,CustomerID=2,ShopProductID=1},
            new CustomerBuy{CustomerBuyID=5,CustomerID=2,ShopProductID=2},
            new CustomerBuy{CustomerBuyID=6,CustomerID=2,ShopProductID=3},
             new CustomerBuy{CustomerBuyID=7,CustomerID=2,ShopProductID=4},
            new CustomerBuy{CustomerBuyID=8,CustomerID=2,ShopProductID=5},
            new CustomerBuy{CustomerBuyID=9,CustomerID=2,ShopProductID=6},
          };
            foreach (CustomerBuy c in customerbuys)
            {
                context.CustomerBuys.Add(c);
            }
            context.SaveChanges();
        }


    }
}
