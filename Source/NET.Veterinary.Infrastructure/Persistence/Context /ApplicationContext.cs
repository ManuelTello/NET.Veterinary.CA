using Microsoft.EntityFrameworkCore;

namespace NET.Veterinary.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ApplicationContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}