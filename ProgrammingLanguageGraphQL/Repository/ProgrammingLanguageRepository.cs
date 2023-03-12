using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Data;
using ProgrammingLanguageGraphQL.Interface;
using ProgrammingLanguageGraphQL.Models;

namespace ProgrammingLanguageGraphQL.Repository
{
    public class ProgrammingLanguageRepository : AbstractRepository<ProgrammingLanguage>
    {
        
        public ProgrammingLanguageRepository(ProgrammingLanguageDbContext context ) : base(context)
        {
        }
    }
}
