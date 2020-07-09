using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Queries.GetBuildings
{
    public class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingsQuery, List<BuildingDTO>>
    {
        private readonly IApplicationDBContext _context;

        public GetAllBuildingsQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<BuildingDTO>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            return _context.Buildings.Include(x => x.Parts).ThenInclude(x => x.Costs).AsNoTracking().Select(x => new BuildingDTO
            {
                Id = x.ExternalId,
                Name = x.Name,
                Budget = x.Budget,
                BudgetReserve = x.BudgetReserve,
                ExpectedTotalCost = x.ExpectedTotalCost,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToListAsync();
        }
    }
}