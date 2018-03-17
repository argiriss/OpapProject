using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using opapProject.Models;

namespace opapProject.Data
{
    public class OpapDbContext :DbContext
    {

        public DbSet<Draw> Draw { get; set; }

        public OpapDbContext(DbContextOptions<OpapDbContext> options) : base(options)
        {

        }
    }
}

//How to add-migration when i have two db contexts
//Add-Migration InitialCreate -Context MainDbContext -OutputDir Data/Migrations
//update-database -context MainDbContext
