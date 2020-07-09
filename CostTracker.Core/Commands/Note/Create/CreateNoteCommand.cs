using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Note.Create
{
    public class CreateNoteCommand:IRequest
    {
        public string BuildingExternalId { get; set; }
        public string Text { get; set; }
    }
}