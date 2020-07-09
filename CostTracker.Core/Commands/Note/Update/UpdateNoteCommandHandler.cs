using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Commands.Note.Update
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly IApplicationDBContext _context;

        public UpdateNoteCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.ExternalId == request.NoteExternalId);
            if (note == null)
                throw new WrongDataException("Note doesn't exists");

            note.UpdateText(request.Text);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}