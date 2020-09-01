using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FasttrackIT_Project.Models;

namespace FasttrackIT_Project.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext (DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<FasttrackIT_Project.Models.Product> Product { get; set; }

        public DbSet<FasttrackIT_Project.Models.Client> Client { get; set; }

        public DbSet<FasttrackIT_Project.Models.OfferHeader> OfferHeader { get; set; }

        public DbSet<FasttrackIT_Project.Models.OfferDetail> OfferDetail { get; set; }
    }
}
