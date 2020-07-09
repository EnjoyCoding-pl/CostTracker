using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Core.Models
{
    /// <summary>
    /// Building object (without notes and parts)
    /// </summary>
    public class BuildingDTO
    {
        /// <summary>
        /// Readonly id value
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        /// <value>Test building</value>
        public string Name { get; set; }
        /// <summary>
        /// Available budget
        /// </summary>
        /// <value>500000</value>
        public decimal Budget { get; set; }

        /// <summary>
        /// Readonly start date of first part
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Readonly end date of last part
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Readonly sum of expected cost in parts
        /// </summary>
        public decimal? ExpectedTotalCost { get; set; }

        /// <summary>
        /// Readonly Budget - ExpectedCost
        /// </summary>
        public decimal? BudgetReserve { get; set; }
    }
}