using Microsoft.AspNetCore.Mvc;
using Otomat.Business.Interface;
using Otomat.Business.Models;

namespace Otomat.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var paymentList = _paymentService.GetList();
            return paymentList != null ? Ok(paymentList) : BadRequest("İşlem Başarısız");
        }

        [HttpPut]
        [Route("buy")]
        public IActionResult Put(ByProductDto product)
        {
            if (product.Product.Id <= 0 && product.Product.Id > 30) BadRequest("Ürün bulunamadı !");
            var receipt = _paymentService.Buy(product);
            return receipt != null ? Ok(receipt) : BadRequest("İşlem Başarısız");
        }


    }
}
