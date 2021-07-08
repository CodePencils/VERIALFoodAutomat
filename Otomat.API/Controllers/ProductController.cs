using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Otomat.Business.Interface;
using Otomat.Business.Models;

namespace Otomat.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]  
        public IActionResult List()
        {
            return Ok(_productService.GetList());
        }


        [HttpGet]
        [Route("/:discount")]
        public IActionResult Get(double discount = 1)
        {
            var productList = _productService.GetDiscountProducts(discount);
            return productList != null ? Ok(productList) : BadRequest("İşlem Başarısız");
        }

        #region İstenirse diğer servisler
        //[HttpGet]
        //[Route(":id")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(_productService.GetList());
        //}

        //[HttpDelete]
        //[Route(":id")]
        //public IActionResult Delete(int id)
        //{
        //    return Ok(_productService.GetList());
        //}

        //[HttpPost]
        //public IActionResult Add(ProductDto product)
        //{
        //    return Ok(_productService.GetList());
        //}

        //[HttpPut]
        //[Route(":id")]
        //public IActionResult Put(int id, ProductDto product)
        //{
        //    return Ok(_productService.GetList());
        //}


        ////[HttpPut]
        ////[Route("/buy")]
        ////public IActionResult Put(ByProductDto byProductDto)
        ////{
        ////    var payResult = _productService.(byProductDto);
        ////    return payResult != null ? Ok(payResult) : BadRequest("İşlem Başarısız");
        ////}
        #endregion




    }
}
