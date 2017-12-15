using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpapProject.Models;

namespace BootstrapMvcSample
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DrawContext _context;

        public DbInitializer(DrawContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            //Create database schema if none exists
            _context.Database.EnsureCreated();

            _context.SaveChanges();

        }
    }
}
