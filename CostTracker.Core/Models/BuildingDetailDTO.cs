using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Core.Models
{
    public class BuildingDetailDTO : BuildingDTO
    {
        public List<PartDTO> Parts { get; set; }

        public List<NoteDTO> Notes { get; set; }
    }
}