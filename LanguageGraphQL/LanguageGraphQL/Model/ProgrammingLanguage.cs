namespace LanguageGraphQL.Model
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int TypeLanguageId { get; set; }
        public virtual TypeLanguage TypeLanguage { get; set; }
    }
}
