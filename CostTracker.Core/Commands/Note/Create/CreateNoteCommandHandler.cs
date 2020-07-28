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

namespace CostTracker.Core.Commands.Note.Create
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand>
    {
        private readonly IApplicationDBContext _context;

        public CreateNoteCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = D.Note.Create(request.Text);

            var building = await _context.Buildings.FirstOrDefaultAsync(x => x.ExternalId == request.BuildingExternalId);

            if (building == null)
                throw new DataException("Building not exists");

            building.AddNote(note);

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}