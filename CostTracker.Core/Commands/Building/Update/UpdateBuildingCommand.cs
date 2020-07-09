using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Building.Update
{
    public class UpdateBuildingCommand:IRequest
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string BuildingExternalId { get; set; }
    }
}