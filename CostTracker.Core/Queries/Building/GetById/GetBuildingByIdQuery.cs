using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Models;
using MediatR;

namespace CostTracker.Core.Queries.GetBuilding
{
    public class GetBuildingByIdQuery : IRequest<BuildingDetailDTO>
    {
        public string ExternalId { get; set; } 
    }
}