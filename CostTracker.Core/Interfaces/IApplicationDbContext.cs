using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CostTracker.Domain.Models;
using System.Threading;

namespace CostTracker.Core.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Building> Buildings { get; set; }
        DbSet<Note> Notes { get; set; }
        DbSet<Cost> Costs { get; set; }
        DbSet<Part> Parts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}