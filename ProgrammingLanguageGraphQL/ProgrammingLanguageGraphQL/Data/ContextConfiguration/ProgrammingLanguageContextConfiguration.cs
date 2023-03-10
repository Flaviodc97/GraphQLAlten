using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingLanguageGraphQL.Models;

namespace ProgrammingLanguageGraphQL.Data.ContextConfiguration
{
    public class ProgrammingLanguageContextConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        private Guid[] _ids;

        public ProgrammingLanguageContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder
                .HasData(
                new ProgrammingLanguage
                {
                    Id = Guid.NewGuid(),
                    Name = "Python",
                    Description = "Python è un linguaggio di programmazione di \"alto livello\", orientato a oggetti, adatto, tra gli altri usi, a sviluppare applicazioni distribuite, scripting, computazione numerica e system testing.",
                    ReleaseDate = new DateTime(2015, 12, 31),
                    TypeLanguageId = _ids[0]
                },
                new ProgrammingLanguage
                {
                    Id = Guid.NewGuid(),
                    Name = "Java",
                    Description = "Java è un linguaggio di programmazione di \"alto livello\", orientato a oggetti, adatto, tra gli altri usi, a sviluppare applicazioni distribuite, scripting, computazione numerica e system testing.",
                    ReleaseDate = new DateTime(2015, 12, 31),
                    TypeLanguageId = _ids[2]
                },
                new ProgrammingLanguage
                {
                    Id = Guid.NewGuid(),
                    Name = "c#",
                    Description = "C# è un linguaggio di programmazione di \"alto livello\", orientato a oggetti, adatto, tra gli altri usi, a sviluppare applicazioni distribuite, scripting, computazione numerica e system testing.",
                    ReleaseDate = new DateTime(2015, 12, 31),
                    TypeLanguageId = _ids[1]


                });
        }

        
    }
}
