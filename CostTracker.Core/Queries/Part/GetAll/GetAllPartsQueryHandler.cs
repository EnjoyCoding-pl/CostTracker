using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Queries.Part.GetAll
{
    public class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQuery, List<PartDTO>>
    {
        private readonly IApplicationDBContext _context;

        public GetAllPartsQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<PartDTO>> Handle(GetAllPartsQuery request, CancellationToken cancellationToken)
        {
            var parts = await _context.Parts.Include(x => x.Building).Include(x => x.Costs).AsNoTracking().Where(x => x.Building.ExternalId == request.BuildingExternalId).ToListAsync();

            return parts.Select(x => new PartDTO
            {
                Budget = x.Budget,
                Id = x.ExternalId,
                EndDate = x.EndDate,
                Name = x.Name,
                BudgetReserve = x.BudgetReserve,
                StartDate = x.StartDate,
                TotalCost = x.TotalCost
            }).ToList();
        }
    }
}