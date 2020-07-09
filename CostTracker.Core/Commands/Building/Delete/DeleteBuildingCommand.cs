using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Building.Delete
{
    public class DeleteBuildingCommand:IRequest
    {
        public string BuildingExternalId { get; set; }
    }
}