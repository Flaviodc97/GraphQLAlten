using ProgrammingLanguageGraphQL.Interface;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingLanguageGraphQL.ViewModels
{
    public class ProgrammingLanguageInput
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public Guid TypeLanguageId { get; set; }
    }
}
