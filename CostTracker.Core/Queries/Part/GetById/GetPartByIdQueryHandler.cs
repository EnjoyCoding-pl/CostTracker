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

        public async Task<PartDetailDTO> Handle(GetPartByIdQuery request, CancellationToken cancellationToken)
        {
            var part = await _context.Parts.Include(x => x.Costs).AsNoTracking().Where(x => x.ExternalId == request.PartExternalId).FirstOrDefaultAsync();

            return new PartDetailDTO
            {
                Budget = part.Budget,
                Id = part.ExternalId,
                EndDate = part.EndDate,
                Name = part.Name,
                BudgetReserve = part.BudgetReserve,
                StartDate = part.StartDate,
                TotalCost = part.TotalCost,
                Costs = part.Costs.Select(c => new CostDTO
                {
                    Id = c.ExternalId,
                    Amount = c.Amount,
                    IsRefund = c.IsRefund,
                    Name = c.Name,
                    VatRate = c.VatRate,
                    InvoiceUrl = c.InvoiceUrl
                }).ToList()
            };
        }
    }
}