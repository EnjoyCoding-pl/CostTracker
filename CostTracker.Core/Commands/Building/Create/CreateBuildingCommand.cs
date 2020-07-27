using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Models;
using MediatR;

namespace CostTracker.Core.Commands.Building.Create
{
    public class CreateBuildingCommand : IRequest
    {
        public string Name { get; set; }
    }
}