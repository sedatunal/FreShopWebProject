using FreeShop.Business.Types;
using FreeShop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Business.Services
{
    public interface IBasketService
    {
        ServiceMessage AddBasket(BasketDto basket);
        List<BasketDto> GetBaskets(int? categoryId = null);

        IEnumerable<BasketDto> GetBasketByUserId(int? userId = null);

        void EditBasket(BasketDto product);

        void DeleteBasket(int id);
    }
}
