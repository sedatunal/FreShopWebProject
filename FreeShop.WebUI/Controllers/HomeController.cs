using FreeShop.Business.Managers;
using FreeShop.Business.Services;
using FreeShop.Data.Dto;
using FreeShop.Data.Entities;
using FreeShop.Data.Migrations;
using FreeShop.Data.Repositories;
using FreeShop.WebUI.Areas.Admin.Models;
using FreeShop.WebUI.Extensions;
using FreeShop.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Security.Claims;


namespace FreeShop.WebUI.Controllers
{
  
    public class HomeController : Controller
    {
       
        
        private readonly IProductService _productService;
        
        private readonly ICategoryService _categoryService;
    
        private readonly ICommentService _commentService;

        

        public HomeController(IProductService productService, ICategoryService categoryService, ICommentService commentService)
        {
            
            _productService = productService;
            _categoryService = categoryService;
            _commentService=commentService;                     

        }

        [Route("/")]
        [Route("urunler/{categoryName}/{categoryId}")]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
            //var b = ((ClaimsIdentity)User.Identities.ToList()[0]).Claims.ToList()[0].Value;

            return View();
        }
        
        public IActionResult Detail(int id)
        {
            

            var productDto = _productService.GetProductById(id);
            var loggedUserId = User.GetUserId();
            var viewModel = new ProductDetailViewModel
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                UnitInStock = productDto.UnitInStock,
                UnitPrice = productDto.UnitPrice,
                ImagePath = productDto.ImagePath,
                CategoryId = productDto.CategoryId,
                UserId= loggedUserId,     
                CategoryName = _categoryService.GetCategoryById(productDto.CategoryId).Name,
                Comments = productDto.Comments.Select(p => new CommentFormViewModel { CommentText = p.CommentText, Rate = p.Rate, ProductId = p.ProductId, Id=p.Id, UserName=p.User.FirstName })

            };
            if (viewModel.Comments.Any())
            viewModel.ProductRate=viewModel.Comments.Average(p => p.Rate).ToString("#.##");
            return View(viewModel);
        }
     
  
        [HttpPost]
        public IActionResult CommentSave(ProductDetailViewModel formData)
        {
            
            if (!ModelState.IsValid)
            {
                var commentDto = new CommentDto
                {
                    ProductId = formData.Id,
                    CommentText = formData.CommentText,
                    Rate = formData.Rate,
                    UserId=formData.UserId,
                    
                    
                   
                };

                _commentService.AddComment(commentDto);

                
            }


            return RedirectToAction("Detail", new {id=formData.Id });
        }



    }
}

