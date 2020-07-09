using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Common.Exceptions;

namespace CostTracker.Domain.Models
{
    public class Building
    {
        public Building()
        {
            Parts = new List<Part>();
            Notes = new List<Note>();
        }
        public static Building Create(string name, decimal budget)
        {
            if (string.IsNullOrEmpty(name))
                throw new WrongDataException($"Missing building name");

            return new Building
            {
                Name = name,
                Budget = budget,
                ExternalId = Guid.NewGuid().ToString().Replace("-", "")
            };
        }
        public int Id { get; private set; }
        public string ExternalId { get; private set; }
        public string Name { get; private set; }
        public decimal Budget { get; private set; }
        public List<Note> Notes { get; }
        public List<Part> Parts { get; }
        public DateTime? StartDate { get => Parts.Any() ? Parts.Min(x => x.StartDate) as DateTime? : null; }
        public DateTime? EndDate { get => Parts.Any() ? Parts.Max(x => x.EndDate) as DateTime? : null; }
        public decimal? ExpectedTotalCost { get => Parts.Any() ? Parts.Sum(x => x.ExpectedCost) as decimal? : null; }
        public decimal? TotalCosts { get => Parts.Any() ? Parts.Sum(x => x.TotalCost) as decimal? : null; }
        public decimal? BudgetReserve { get => TotalCosts.HasValue ? (Budget - TotalCosts.Value) as decimal? : null; }

        public void AddNote(Note note)
        {
            note.BuildingId = Id;
            note.Building = this;

            Notes.Add(note);
        }

        public void AddPart(Part part)
        {
            part.BuildingId = Id;
            part.Building = this;

            Parts.Add(part);
        }
        public void Update(string name, decimal budget)
        {
            Name = name;
            Budget = budget;
        }
    }
}