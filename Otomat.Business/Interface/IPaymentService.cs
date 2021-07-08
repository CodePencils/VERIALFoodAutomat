using Otomat.Business.Models;
using System.Collections.Generic;

namespace Otomat.Business.Interface
{
    public interface IPaymentService
    {
        List<PaymentDto> GetList();
        public ReceiptDto Buy(ByProductDto byProductDto);
    }
}
