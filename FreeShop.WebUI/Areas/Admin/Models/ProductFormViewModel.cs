using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FreeShop.WebUI.Areas.Admin.Models
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün Adı girmek zorunlu.")]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }

        [Display(Name = "Ürün Görseli")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Bir kategori seçmek zorunlu.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
    }
}
