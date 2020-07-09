using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Core.Models
{
    public class PartDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal ExpectedCost { get; set; }
        public int ProgressRatio { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? Reserve { get; set; }
    }
}