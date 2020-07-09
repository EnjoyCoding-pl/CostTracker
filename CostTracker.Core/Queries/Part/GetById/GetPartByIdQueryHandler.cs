using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Queries.Part.GetById
{
    public class GetPartByIdQueryHandler : IRequestHandler<GetPartByIdQuery, PartDetailDTO>
    {
        private readonly IApplicationDBContext _context;

        public GetPartByIdQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public Task<PartDetailDTO> Handle(GetPartByIdQuery request, CancellationToken cancellationToken)
        {
            return _context.Parts.Include(x => x.Costs).AsNoTracking().Where(x=>x.ExternalId == request.PartExternalId).Select(x => new PartDetailDTO
            {
                ExpectedCost = x.ExpectedCost,
                Id = x.ExternalId,
                EndDate = x.EndDate,
                Name = x.Name,
                Reserve = x.Reserve,
                StartDate = x.StartDate,
                TotalCost = x.TotalCost,
                Costs = x.Costs.Select(c => new CostDTO
                {
                    Id = c.ExternalId,
                    Amount = c.Amount,
                    IsRefund = c.IsRefund,
                    Name = c.Name,
                    VatRate = c.VatRate,
                    InvoiceUrl = c.InvoiceUrl
                }).ToList()
            }).FirstOrDefaultAsync();
        }
    }
}