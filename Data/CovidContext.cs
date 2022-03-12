using ApiCovid.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCovid.Data
{
    public class CovidContext : DbContext
    {
        public CovidContext(DbContextOptions<CovidContext> opt) : base(opt)
        {

        }

        public DbSet<CasoCovid> CasoCovids { get; set; }
    }
}
