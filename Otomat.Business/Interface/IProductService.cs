using Otomat.Business.Models;
using System.Collections.Generic;

namespace Otomat.Business.Interface
{
    public interface IProductService
    {
        List<ProductDto> GetList();
        List<ProductDto> GetDiscountProducts(double discount);

        
    }
}
