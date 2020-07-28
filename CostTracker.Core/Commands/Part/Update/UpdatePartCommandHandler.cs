using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Commands.Part.Update
{
    public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommand>
    {
        private readonly IApplicationDBContext _context;

        public UpdatePartCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePartCommand request, CancellationToken cancellationToken)
        {
            var part = await _context.Parts.FirstOrDefaultAsync(x => x.ExternalId == request.PartExternalId);

            if (part == null)
                throw new DataException("Part doesn't exists");

            part.Update((request.Name, request.Budget, request.StartDate, request.EndDate));

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}