using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Models;
using MediatR;

namespace CostTracker.Core.Queries.Part.GetById
{
    public class GetPartByIdQuery:IRequest<PartDetailDTO>
    {
        public string PartExternalId { get; set; }
    }
}