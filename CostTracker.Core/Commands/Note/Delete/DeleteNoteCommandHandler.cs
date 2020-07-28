using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Commands.Note.Delete
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly IApplicationDBContext _context;

        public DeleteNoteCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.ExternalId == request.NoteExternalId);

            if (note == null)
                throw new DataException("Note doesn't exists");

            _context.Notes.Remove(note);
            
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}