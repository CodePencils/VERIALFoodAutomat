using Otomat.Business.Models;
using System.Collections.Generic;

namespace Otomat.Business.Interface
{
    public interface IPaymentService
    {
        /// <summary>
        /// Ödeme yöntemlerini listeler
        /// </summary> 
        /// <returns> List PaymentDto payments </returns>
        List<PaymentDto> GetList();
        /// <summary>
        /// Ürün satışı yapılır geri fiş döner.
        /// </summary>
        /// <param name="ByProductDto"></param>
        /// <returns> ReceiptDto receiptdto </returns>
        public ReceiptDto Buy(ByProductDto byProductDto);
    }
}
