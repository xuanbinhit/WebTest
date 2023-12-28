using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Models
{
    public class Shop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ShopID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
