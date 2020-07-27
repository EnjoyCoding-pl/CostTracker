using System;

namespace CostTracker.Core.Models
{
    public class PartDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? BudgetReserve { get; set; }
    }
}