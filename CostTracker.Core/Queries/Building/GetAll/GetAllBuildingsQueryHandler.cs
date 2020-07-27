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

        public async Task<List<BuildingDTO>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            var buildings = await _context.Buildings.Include(x => x.Parts).ThenInclude(x => x.Costs).AsNoTracking().ToListAsync();

            return buildings.Select(x => new BuildingDTO
            {
                Id = x.ExternalId,
                Name = x.Name,
                TotalBudgetReserve = x.TotalBudgetReserve,
                TotalBudget = x.TotalBudget,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToList();
        }
    }
}