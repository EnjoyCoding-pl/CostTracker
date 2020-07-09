using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;

namespace CostTracker.Domain.Models
{
    public class Part
    {
        public Part()
        {
            Costs = new List<Cost>();
        }
        public static Part Create((string Name, decimal ExpectedCost, DateTime StartDate, DateTime EndDate) part)
        {
            Validate(part.Name, part.ExpectedCost);

            return new Part
            {
                Name = part.Name,
                ExpectedCost = part.ExpectedCost,
                StartDate = part.StartDate,
                EndDate = part.EndDate,
                ExternalId = Guid.NewGuid().ToString().Replace("-", "")
            };
        }
        public int Id { get; private set; }
        public string ExternalId { get; private set; }
        public string Name { get; private set; }
        public decimal ExpectedCost { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public List<Cost> Costs { get; }
        public decimal? TotalCost { get => Costs.Any() ? Costs.Sum(x => x.Amount) as decimal? : null; }
        public decimal? Reserve { get => TotalCost.HasValue ? ExpectedCost - TotalCost.Value as decimal? : null; }

        public void AddCost(Cost cost)
        {
            if (Costs.Sum(x => x.Amount) + cost.Amount < 0)
                throw new WrongDataException("Refund can't exceed cost");

            cost.PartId = Id;
            cost.Part = this;

            this.Costs.Add(cost);
        }

        public void Update((string Name, decimal ExpectedCost, DateTime StartDate, DateTime EndDate) part)
        {
            Validate(part.Name, part.ExpectedCost);

            Name = part.Name;
            StartDate = part.StartDate;
            EndDate = part.EndDate;
            ExpectedCost = part.ExpectedCost;
        }

        private static void Validate(string Name, decimal ExpectedCost)
        {
            if (ExpectedCost < 0)
                throw new WrongDataException("Part expected cost can't be negative");

            if (string.IsNullOrEmpty(Name))
                throw new WrongDataException("Missing part name");
        }
    }
}