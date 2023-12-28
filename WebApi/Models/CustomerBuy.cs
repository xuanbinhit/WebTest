using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Models
{
    public class CustomerBuy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerBuyID { get; set; }
        public int CustomerID { get; set; }
        public int ShopProductID { get; set; }
    }
}
