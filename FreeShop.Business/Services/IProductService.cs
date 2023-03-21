using FreeShop.Business.Types;
using FreeShop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Business.Services
{
    public interface IProductService
    {
        ServiceMessage AddProduct(ProductDto product);
        List<ProductDto> GetProducts(int? categoryId = null);

        ProductDto GetProductById(int id);

        void EditProduct(ProductDto product);

        void DeleteProduct(int id);
    }
}
