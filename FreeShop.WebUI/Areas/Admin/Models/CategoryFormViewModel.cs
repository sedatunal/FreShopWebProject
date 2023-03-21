﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FreeShop.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Kategori Adı girmek zorunludur.")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }
}
