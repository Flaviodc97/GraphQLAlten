using AutoMapper;
using ProgrammingLanguageGraphQL.Models;
using ProgrammingLanguageGraphQL.ViewModels;

namespace ProgrammingLanguageGraphQL.Data
{
    public class Mutation

    {
        private readonly ProgrammingLanguageDbContext _dbContext;
        private readonly IMapper _mapper;
        public Mutation(ProgrammingLanguageDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<ProgrammingLanguage> CreateLanguage([Service] ProgrammingLanguageDbContext programmingLanguageDbContext, string name,DateTime releaseDate,string description, Guid typeLanguageId)
        {
            var language = new ProgrammingLanguage 
            {
                Name = name,
                ReleaseDate = releaseDate,
                Description = description,
                TypeLanguageId = typeLanguageId
            };
            await _dbContext.AddAsync(language);
            await _dbContext.SaveChangesAsync();
             return language;
        }
        public async Task<TypeLanguage> CreateTypeLanguage([Service] ProgrammingLanguageDbContext programmingLanguageDbContext,string name)
        {
            var type = new TypeLanguage
            {
                Name = name,
            };
            await _dbContext.AddAsync(type);
            await _dbContext.SaveChangesAsync();
            return type;
        }
    }
}
