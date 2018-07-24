using Microsoft.EntityFrameworkCore;

namespace Criminals.API.Models
{
    public class CriminalsContext : DbContext
    {
        public DbSet<CaseReport> CaseReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Integrated Security=False;User Id=SA;Password=yourStrong(!)Password;MultipleActiveResultSets=True");
        }
    }
}