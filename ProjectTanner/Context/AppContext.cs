using Microsoft.EntityFrameworkCore;
using ProjectTanner.Models;

namespace ProjectTanner.Context
{
    public class AppContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!; 
        public DbSet<Models.Task> Tasks { get; set; } = null!; 

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=.;user=root;password=123456789;database=usersdb;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }
}
