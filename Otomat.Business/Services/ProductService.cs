using Newtonsoft.Json;
using Otomat.Business.Interface;
using Otomat.Business.Models;
using Otomat.Data;
using System.Collections.Generic;

namespace Otomat.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProducts products;
        public ProductService(IProducts _products)
        {
            products = _products;
        }

       
        public List<ProductDto> GetList()
        { 
            return JsonConvert.DeserializeObject<List<ProductDto>>(products.Products()); 
        }

        public List<ProductDto> GetDiscountProducts(double disocunt = 1)
        {
            // İleride indirim gibi kampanyalar buradan kontrol edelebilir.
            var productList = JsonConvert.DeserializeObject<List<ProductDto>>(products.Products());
            foreach (var item in productList)
            {
                item.Price = item.Price * disocunt;
            };

            return productList;
        }

    }
}
