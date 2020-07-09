using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Part.Delete
{
    public class DeletePartCommand:IRequest
    {
        public string PartExternalId { get; set; }
    }
}