using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpapProject.Models
{
    public class DrawContext : DbContext
    {
        public DbSet<Draw> Klirosis { get; set; }

        public DrawContext(DbContextOptions<DrawContext> options)
            : base(options)
        {

        }
    }
}