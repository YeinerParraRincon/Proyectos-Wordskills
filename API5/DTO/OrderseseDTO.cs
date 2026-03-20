using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderseseDTO
    {
        public long TransactionId { get; set; }

        public long CustomerId { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public string Channel { get; set; } = null!;

        public byte StoreId { get; set; }

        public byte PromotionId { get; set; }

        public double DiscountAmount { get; set; }

        public int Total { get; set; }

        public string Status { get; set; } = null!;

        public int OrderItems { get; set; }
    }
}
