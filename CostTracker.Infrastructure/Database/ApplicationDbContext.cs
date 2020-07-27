using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDBContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}