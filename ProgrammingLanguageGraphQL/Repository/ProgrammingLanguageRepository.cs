using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Data;
using ProgrammingLanguageGraphQL.Interface;

namespace ProgrammingLanguageGraphQL.Repository
{
    public class ProgrammingLanguageRepository : IProgrammingLanguageRepository
    {
        private readonly ProgrammingLanguageDbContext _context;
        public ProgrammingLanguageRepository(ProgrammingLanguageDbContext context)
        {
            _context= context;
        }

    }
}
