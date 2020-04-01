using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Models
{
    public class MemoryContext : DbContext
    {
        public MemoryContext (DbContextOptions<MemoryContext> options)
            : base(options)
        {
        }

        public DbSet<Memory.Models.Partie> Partie { get; set; }

        public DbSet<Memory.Models.Carte> Carte { get; set; }

        public DbSet<Memory.Models.ScorePartie> ScorePartie { get; set; }
    }
}
