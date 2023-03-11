using System.ComponentModel.DataAnnotations;

namespace ProgrammingLanguageGraphQL.Models
{
    public class TypeLanguage
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<ProgrammingLanguage> ProgrammingLanguages { get; set;}
    }
}
