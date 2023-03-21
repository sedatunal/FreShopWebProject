using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FreeShop.WebUI.Models
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        
        public int Piece { get; set; }

        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string ImagePath { get; set; }
        
        public decimal? SumTotal { get; set; }




    }
}
