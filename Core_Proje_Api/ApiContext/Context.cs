using Core_Proje_Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-6JPMHUC\\SQLSERVERFIRST;database=CoreProjeDB2;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
