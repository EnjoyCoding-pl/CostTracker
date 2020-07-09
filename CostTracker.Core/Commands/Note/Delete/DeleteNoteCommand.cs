using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Note.Delete
{
    public class DeleteNoteCommand:IRequest
    {
        public string NoteExternalId { get; set; }
    }
}