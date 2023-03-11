using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Data.ContextConfiguration;
using ProgrammingLanguageGraphQL.Models;

namespace ProgrammingLanguageGraphQL.Data
{
    public class ProgrammingLanguageDbContext : DbContext
    {
        public ProgrammingLanguageDbContext(DbContextOptions<ProgrammingLanguageDbContext> options) : base (options) 
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            builder.ApplyConfiguration(new TypeLanguageContextConfiguration(ids));
            builder.ApplyConfiguration(new ProgrammingLanguageContextConfiguration(ids));
           
        }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<TypeLanguage> Types { get; set; }
    }
}
