using ProgrammingLanguageGraphQL.Models;

namespace ProgrammingLanguageGraphQL.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProgrammingLanguage> GetLanguages([Service] ProgrammingLanguageDbContext context) =>
            context.ProgrammingLanguages;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TypeLanguage> GetType([Service] ProgrammingLanguageDbContext context) =>
            context.Types;
    }
}
