using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Note.Update
{
    public class UpdateNoteCommand:IRequest
    {
        public string NoteExternalId { get; set; }
        public string Text { get; set; }
    }
}