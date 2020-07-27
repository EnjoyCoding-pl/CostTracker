using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Core.Models;
using CostTracker.Core.Queries.Note.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Core.Queries.Cost.GetAll
{
    public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, List<NoteDTO>>
    {
        private readonly IApplicationDBContext _context;

        public GetAllNotesQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<NoteDTO>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = await _context.Notes.Include(x => x.Building).AsNoTracking().Where(x => x.Building.ExternalId == request.BuildingExternalId).ToListAsync();

            return notes.Select(x => new NoteDTO
            {
                Id = x.ExternalId,
                Text = x.Text
            }).ToList();
        }
    }
}