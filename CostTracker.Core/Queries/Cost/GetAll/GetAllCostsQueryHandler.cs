using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Queries.Cost.GetAll
{
    public class GetAllCostsQueryHandler : IRequestHandler<GetAllCostsQuery, List<CostDTO>>
    {
        private readonly IApplicationDBContext _context;

        public GetAllCostsQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<CostDTO>> Handle(GetAllCostsQuery request, CancellationToken cancellationToken)
        {
            return _context.Costs.Include(x => x.Part).AsNoTracking().Where(x => x.Part.ExternalId == request.PartExternalId).Select(x => new CostDTO
            {
                Amount = x.Amount,
                Id = x.ExternalId,
                VatRate = x.VatRate,
                Name = x.Name,
                IsRefund = x.IsRefund,
                InvoiceUrl = x.InvoiceUrl
            }).ToListAsync();
        }
    }
}