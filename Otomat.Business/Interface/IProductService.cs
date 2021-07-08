using Otomat.Business.Models;
using System.Collections.Generic;

namespace Otomat.Business.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// Ürünleri listeler.
        /// </summary> 
        /// <returns> List ProductDto products </returns>
        List<ProductDto> GetList();
        /// <summary>
        /// İndirim oranına göre ürünleri listeler.
        /// </summary>
        /// <param name="discount"></param>
        /// <returns> List ProductDto products </returns>
        List<ProductDto> GetDiscountProducts(double discount);

        
    }
}
