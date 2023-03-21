using FreeShop.Business.Services;
using FreeShop.Data.Dto;
using FreeShop.Data.Entities;
using FreeShop.WebUI.Areas.Admin.Models;
using FreeShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeShop.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;

        public CommentController(ICommentService commentService, IProductService productService)
        {
            _commentService = commentService;
            _productService = productService;
        }




        [HttpGet]
        public IActionResult New()
        {
            var products = _productService.GetProducts();
            ViewBag.Products = products;

            return View("form", new CommentFormViewModel());
        }

        [HttpPost]
        public IActionResult Save(CommentFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                var products = _productService.GetProducts();
                ViewBag.Products = products;
                return View("form", formData);
            }

         

            if (formData.Id == 0)
            {

                var commentDto = new CommentDto()
                {
                    Id = formData.Id,
                    CommentText = formData.CommentText,
                    Rate = formData.Rate,
                   ProductId=ViewBag.Products.ProductId
                   
                };

                var response = _commentService.AddComment(commentDto);

                if (response.IsSucceed)
                {
                    return RedirectToAction("index");
                }
                else
                {

                    var products = _productService.GetProducts();
                    ViewBag.Products = products;

                    ViewBag.ErrorMessage = response.Message;
                    return View("form", formData);
                }
            }
            else
            {
                var commentDto = new CommentDto()
                {
                    Id = formData.Id,
                    CommentText = formData.CommentText,
                    Rate = formData.Rate,
                    ProductId = formData.ProductId,
                };

               
               
            }
            return RedirectToAction("index");
        }

    }
    }

