using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using D = CostTracker.Domain.Models;
using MediatR;
using CostTracker.Core.Interfaces;

namespace CostTracker.Core.Commands.Building.Create
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand>
    {
        private readonly IApplicationDBContext _context;
        public CreateBuildingCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = D.Building.Create(request.Name);

            await _context.Buildings.AddAsync(building);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}