using Newtonsoft.Json;
using Otomat.Business.Enum;
using Otomat.Business.Interface;
using Otomat.Business.Models;
using Otomat.Data.Operations;
using System.Collections.Generic;

namespace Otomat.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPayments payemnts;
        public PaymentService(IPayments _payemnts)
        {
            payemnts = _payemnts;
        }

        public List<PaymentDto> GetList()
        {
            return JsonConvert.DeserializeObject<List<PaymentDto>>(payemnts.Payments());
        }

        public ReceiptDto Buy(ByProductDto byProductDto)
        {
            // yapılacaksa data katmanına gönderilecek.
            return new ReceiptDto()
            {
                Name = (byProductDto.Product.Name??"").ToString(),
                PayName = ((PaymentOption)byProductDto.PaymentOption).ToString(),
                Quantitiy = byProductDto.Quantity,
                Refund = (byProductDto.PaymentOption == PaymentOption.WithCoin || byProductDto.PaymentOption == PaymentOption.WithBaknote) ? byProductDto.Money - (byProductDto.Product.Price*byProductDto.Quantity) : 0
            };

        }
    }
}
