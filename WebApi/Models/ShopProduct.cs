using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Models
{
    public class ShopProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ShopProductID { get; set; }
        public int ShopID { get; set; }
        public int ProductID { get; set; }
    }
}
