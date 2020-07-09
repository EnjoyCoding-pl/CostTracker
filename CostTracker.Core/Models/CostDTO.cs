using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Core.Models
{
    public class CostDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int VatRate { get; set; }
        public bool IsRefund { get; set; }
        public string InvoiceUrl { get; set; }
    }
}