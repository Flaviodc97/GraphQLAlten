using LanguageGraphQL.Model;
using Microsoft.EntityFrameworkCore;

namespace LanguageGraphQL.Data
{
    public class ProgrammingLanguageContext : DbContext
    {
        public ProgrammingLanguageContext(DbContextOptions<ProgrammingLanguageContext> option) : base(option)
        {

        }
        public DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set;}
        public DbSet<TypeLanguage> TypeLanguage { get; set;}
    }
}
