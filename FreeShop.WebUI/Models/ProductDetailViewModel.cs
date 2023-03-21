using FreeShop.Data.Entities;
using System.Xml.Linq;

namespace FreeShop.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CommentId { get; set; }
        public IEnumerable<CommentFormViewModel>? Comments { get; set; }
        public string CommentText { get; set; }
        public int Rate { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string ProductRate { get; set; }

    }
}
