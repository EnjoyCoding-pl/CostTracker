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
        public Task<List<PartDTO>> Handle(GetAllPartsQuery request, CancellationToken cancellationToken)
        {
            return _context.Parts.Include(x => x.Building).Include(x => x.Costs).AsNoTracking().Where(x => x.Building.ExternalId == request.BuildingExternalId).Select(x => new PartDTO
            {
                ExpectedCost = x.ExpectedCost,
                Id = x.ExternalId,
                EndDate = x.EndDate,
                Name = x.Name,
                Reserve = x.Reserve,
                StartDate = x.StartDate,
                TotalCost = x.TotalCost
            }).ToListAsync();
        }
    }
}