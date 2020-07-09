using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Cost.Create
{
    public class CreateCostCommand:IRequest
    {
        public string PartExternalId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int VatRate { get; set; }
        public Stream File { get; set; }
        public string FileName { get; set; }
    }
}