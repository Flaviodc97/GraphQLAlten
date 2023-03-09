using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LanguageGraphQL.Model
{
    public class TypeLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ProgrammingLanguage> Languages { get; set; }
    }
}
