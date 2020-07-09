using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Domain.Models
{
    public class Note
    {
        public static Note Create(string text)
        {
            return new Note
            {
                Text = text,
                ExternalId = Guid.NewGuid().ToString().Replace("-", "")
            };
        }
        public int Id { get; set; }
        public string ExternalId { get; private set; }
        public string Text { get; private set; }
        public bool IsRemoved { get; private set; }

        public int BuildingId { get; set; }

        public Building Building { get; set; }

        public void UpdateText(string text)
        {
            Text = text;
        }
    }
}