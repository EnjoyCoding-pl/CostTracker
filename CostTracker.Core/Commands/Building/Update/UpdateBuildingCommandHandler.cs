using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Commands.Building.Update
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand>
    {
        private readonly IApplicationDBContext _context;

        public UpdateBuildingCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _context.Buildings.FirstOrDefaultAsync(x => x.ExternalId == request.BuildingExternalId);

            if (building == null)
                throw new DataException($"Building not exists");

            building.Update(request.Name);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}