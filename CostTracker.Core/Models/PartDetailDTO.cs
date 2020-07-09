using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Core.Models
{
    public class PartDetailDTO:PartDTO
    {
        public List<CostDTO> Costs { get; set; }
    }
}