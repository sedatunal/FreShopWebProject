using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FreeShop.WebUI.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Eposta")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        [Required]
        public string Address { get; set; }

    }
}
