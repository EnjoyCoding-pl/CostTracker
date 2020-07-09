using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using D = CostTracker.Domain.Models;

namespace CostTracker.Core.Commands.Part.Create
{
    public class CreatePartCommandHandler : IRequestHandler<CreatePartCommand>
    {
        private readonly IApplicationDBContext _context;

        public CreatePartCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreatePartCommand request, CancellationToken cancellationToken)
        {
            var part = D.Part.Create((request.Name, request.ExpectedCost,request.StartDate,request.EndDate));

            var building = await _context.Buildings.Include(x => x.Parts).FirstOrDefaultAsync(x => x.ExternalId == request.BuildingExternalId);

            if (building == null)
                throw new WrongDataException("Missing building");

            building.AddPart(part);

            // await _context.Parts.AddAsync(part);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}