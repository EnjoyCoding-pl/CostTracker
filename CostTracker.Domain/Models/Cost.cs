using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;

namespace CostTracker.Domain.Models
{
    public class Cost
    {
        public static Cost Create(string name, decimal amount, int vatRate)
        {
            if (string.IsNullOrEmpty(name))
                throw new WrongDataException("Missing cost name");

            return new Cost
            {
                Name = name,
                Amount = amount,
                VatRate = vatRate,
                IsRefund = amount < 0,
                ExternalId = Guid.NewGuid().ToString().Replace("-", "")
            };
        }
        public int Id { get; set; }
        public string ExternalId { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        public int VatRate { get; private set; }
        public bool IsRefund { get; private set; }
        public Part Part { get; set; }
        public int PartId { get; set; }
        public string InvoiceUrl { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {Amount}"; 
        }

        public void SetInvoiceUrl(string url)
        {
            InvoiceUrl = url;
        }
    }
}