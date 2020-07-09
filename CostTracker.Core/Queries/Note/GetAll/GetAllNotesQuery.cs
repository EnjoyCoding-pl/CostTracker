using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Models;
using MediatR;

namespace CostTracker.Core.Queries.Note.GetAll
{
    public class GetAllNotesQuery:IRequest<List<NoteDTO>>
    {
        public string BuildingExternalId { get; set; }
    }
}