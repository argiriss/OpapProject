using opapProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opapProject.Models.Services
{
    public class EfDrawRepository : IDrawRepository
    {
        private OpapDbContext db;

        public IQueryable<Draw> Draws {
            get
            {
                return db.Draw;
            }
        }

        //writing the above with expression body
        //public IQueryable<draw> Draws => db.draw;

        //Depedency injection implemented on constructor.Instatiate db object
        public EfDrawRepository(OpapDbContext db)
        {
            this.db = db;
        }

        //Methods
        public async Task AddDraw(Draw draw)
        {
                db.Draw.Add(draw);
                await db.SaveChangesAsync();          
        }
    }
}
