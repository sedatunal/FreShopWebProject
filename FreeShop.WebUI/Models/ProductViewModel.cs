using FreeShop.Data.Entities;

namespace FreeShop.WebUI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImagePath { get; set; }


      
    }
}
