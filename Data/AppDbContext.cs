using InterfaceDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterfaceDB.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ActivationHistory> activation_history => Set<ActivationHistory>();
        public DbSet<Department> department => Set<Department>();
        public DbSet<Pass> pass => Set<Pass>();
        public DbSet<PassType> pass_type => Set<PassType>();
        public DbSet<User> user => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=passes;user=root;password=1981";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
