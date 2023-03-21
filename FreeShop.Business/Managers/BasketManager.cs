using FreeShop.Business.Services;
using FreeShop.Business.Types;
using FreeShop.Data.Dto;
using FreeShop.Data.Entities;
using FreeShop.Data.Migrations;
using FreeShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Business.Managers
{
    public class BasketManager : IBasketService
    {

        private readonly IRepository<BasketEntity> _basketRepository;
        public BasketManager(IRepository<BasketEntity> basketRepository)
        {
            _basketRepository = basketRepository;
        }


        public ServiceMessage AddBasket(BasketDto basket)
        {

            var hasBasket = _basketRepository.GetAll(p => p.ProductId == basket.ProductId && p.UserId == basket.UserId).FirstOrDefault();

            if (hasBasket != null)
            {
                hasBasket.Piece++;
                _basketRepository.Update(hasBasket);
                return new ServiceMessage
                {
                    IsSucceed = true
                };
            }



            else
            {
                var basketEntity = new BasketEntity()
                {
                    Id = basket.Id,
                    ProductId = basket.ProductId,
                    UserId = basket.UserId,
                    Piece = basket.Piece

                };

                _basketRepository.Add(basketEntity);

                return new ServiceMessage
                {
                    IsSucceed = true
                };
            }
        }

        public void DeleteBasket(int id)
        {
            _basketRepository.Delete(id);
        }

        public void EditBasket(BasketDto product)
        {
           throw new NotImplementedException();
        }

        public IEnumerable<BasketDto> GetBasketByUserId(int? userId = null)
        {

            var query = _basketRepository.GetAll();

            if (userId.HasValue)
                query = query.Where(x => x.UserId == userId.Value);

            var basketEntities = query.OrderBy(x => x.ModifiedDate);


            var basketList = basketEntities.Select(x => new BasketDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,
                Piece=x.Piece

            }).ToList();

            return basketList;



            //var basketEntity = _basketRepository.GetAll(p => p.UserId == id).Include(m => m.ProductId);

            //var userBasket = new List<BasketDto>();

            //userBasket = basketEntity.Select(p => new BasketDto()
            //{
            //    Id = p.Id,
            //    ProductId = p.ProductId,
            //    UserId = p.UserId,
            //    Piece = p.Piece
            //}).ToList();

            //return userBasket;
        }

        public List<BasketDto> GetBaskets(int? categoryId = null)
        {
            throw new NotImplementedException();
        }
    }
}
