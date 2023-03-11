using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Models;

namespace ProgrammingLanguageGraphQL.Data.ContextConfiguration
{
    public class TypeLanguageContextConfiguration : IEntityTypeConfiguration<TypeLanguage>
    {
        private Guid[] _ids;

        public TypeLanguageContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<TypeLanguage> builder)
        {
            builder
                .HasData(
                new TypeLanguage
                {
                    Id = _ids[0],
                    Name = "Procedural programming languages",
                    
                },
                new TypeLanguage
                {
                    Id = _ids[1],
                    Name = "Functional programming languages",
                    
                },
                new TypeLanguage
                {
                    Id = _ids[2],
                    Name = "Object-oriented programming languages",
                  
                },
                new TypeLanguage
                {
                    Id = _ids[3],
                    Name = "Scripting languages",

                });
        }
    }
}

