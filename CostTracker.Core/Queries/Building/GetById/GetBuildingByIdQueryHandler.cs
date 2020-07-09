using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Queries.GetBuilding
{
    public class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQuery, BuildingDetailDTO>
    {
        private readonly IApplicationDBContext _context;

        public GetBuildingByIdQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<BuildingDetailDTO> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            var building = await _context.Buildings
            .Include(x => x.Notes)
            .Include(x => x.Parts)
            .ThenInclude(x => x.Costs)
            .AsNoTracking()
            .FirstAsync(x => x.ExternalId == request.ExternalId);

            return new BuildingDetailDTO
            {
                Name = building.Name,
                Budget = building.Budget,
                BudgetReserve = building.BudgetReserve,
                ExpectedTotalCost = building.ExpectedTotalCost,
                StartDate = building.StartDate,
                EndDate = building.EndDate,
                Notes = building.Notes.Select(x => new NoteDTO
                {
                    Id = x.ExternalId,
                    Text = x.Text
                }).ToList(),
                Parts = building.Parts.Select(x => new PartDTO
                {
                    Id = x.ExternalId,
                    ExpectedCost = x.ExpectedCost,
                    Name = x.Name,
                    EndDate = x.EndDate,
                    Reserve = x.Reserve,
                    StartDate = x.StartDate,
                    TotalCost = x.TotalCost
                }).ToList()
            };
        }
    }
}