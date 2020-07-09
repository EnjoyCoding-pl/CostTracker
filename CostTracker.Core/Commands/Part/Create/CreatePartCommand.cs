using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CostTracker.Core.Commands.Part.Create
{
    public class CreatePartCommand : IRequest
    {
        public string BuildingExternalId { get; set; }
        public string Name { get; set; }
        public decimal ExpectedCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}