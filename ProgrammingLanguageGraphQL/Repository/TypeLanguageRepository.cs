using ProgrammingLanguageGraphQL.Data;
using ProgrammingLanguageGraphQL.Interface;

namespace ProgrammingLanguageGraphQL.Repository
{
    public class TypeLanguageRepository : ITypeLanguageRepository
    {
        private readonly ProgrammingLanguageDbContext _context;
        public TypeLanguageRepository(ProgrammingLanguageDbContext context)
        {
            _context = context;
        }
    }
}
