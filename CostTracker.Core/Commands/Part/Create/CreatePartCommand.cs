using System;
using MediatR;

namespace CostTracker.Core.Commands.Part.Create
{
    public class CreatePartCommand : IRequest
    {
        public string BuildingExternalId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}