using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Commands.Part.Delete
{
    public class DeletePartCommandHandler : IRequestHandler<DeletePartCommand>
    {
        private readonly IApplicationDBContext _context;

        public DeletePartCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePartCommand request, CancellationToken cancellationToken)
        {
            var part = await _context.Parts.FirstOrDefaultAsync(x => x.ExternalId == request.PartExternalId);

            if (part != null)
            {
                _context.Parts.Remove(part);
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}