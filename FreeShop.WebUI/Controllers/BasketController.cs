using FreeShop.Business.Services;
using FreeShop.Data.Dto;
using FreeShop.Data.Migrations;
using FreeShop.WebUI.Extensions;
using FreeShop.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreeShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        
        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
           
        }
       
        public IActionResult Index()
        {
            var loggedUserId = User.GetUserId();
            var baskets = _basketService.GetBasketByUserId(loggedUserId);
            

            var viewModel = baskets.Select(x => new BasketViewModel
            {
                
                Id = x.Id,
                Piece = x.Piece,
                ProductName=_productService.GetProductById(x.ProductId).Name,
                UnitPrice= _productService.GetProductById(x.ProductId).UnitPrice,
                TotalPrice=x.Piece* _productService.GetProductById(x.ProductId).UnitPrice,
                ImagePath=_productService.GetProductById(x.ProductId).ImagePath,
              


            }).ToList();

            var SumTotal = viewModel.Sum(p => p.TotalPrice); 
            ViewBag.SumTotal = SumTotal;
        
            return View(viewModel);
        }

   
        public  IActionResult Add(int id)
        {
           
            var loggedUserId = User.GetUserId();
            BasketDto basket = new BasketDto()
            {
               
                UserId=loggedUserId,
                ProductId = id,
                Piece=1

            };
            _basketService.AddBasket(basket);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _basketService.DeleteBasket(id);

            return RedirectToAction("index");
        }
    }
}

