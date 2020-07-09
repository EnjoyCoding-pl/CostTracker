using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using MediatR;

namespace CostTracker.Core.Commands.Building.Delete
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand>
    {
        private readonly IApplicationDBContext _context;
        public DeleteBuildingCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _context.Buildings.FindAsync(request.BuildingExternalId);

            if (building != null)
            {
                _context.Buildings.Remove(building);
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}