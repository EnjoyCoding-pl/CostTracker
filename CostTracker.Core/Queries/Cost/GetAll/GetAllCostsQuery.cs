using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Models;
using MediatR;

namespace CostTracker.Core.Queries.Cost.GetAll
{
    public class GetAllCostsQuery:IRequest<List<CostDTO>>
    {
        public string PartExternalId { get; set; }
    }
}