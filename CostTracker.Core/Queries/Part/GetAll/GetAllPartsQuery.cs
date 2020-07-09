using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Models;
using MediatR;

namespace CostTracker.Core.Queries.Part.GetAll
{
    public class GetAllPartsQuery:IRequest<List<PartDTO>>
    {
        public string BuildingExternalId { get; set; }
    }
}