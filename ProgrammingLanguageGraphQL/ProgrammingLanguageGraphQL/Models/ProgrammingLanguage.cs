using ProgrammingLanguageGraphQL.Interface;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingLanguageGraphQL.Models
{
    public class ProgrammingLanguage
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public Guid TypeLanguageId { get; set; }
        public virtual TypeLanguage TypeLanguage { get; set; }
    }
}
