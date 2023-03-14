using AutoMapper;
using ProgrammingLanguageGraphQL.Models;
using ProgrammingLanguageGraphQL.ViewModels;

namespace ProgrammingLanguageGraphQL.NewFolder
{
    public class ProgrammingLanguageMappingProfile : Profile
    {
        public ProgrammingLanguageMappingProfile()
        {
            CreateMap<TypeLanguageInput, TypeLanguage>()
                .ForMember(u => u.Id, opt => opt.Ignore());
            CreateMap<ProgrammingLanguageInput, ProgrammingLanguage>()
                .ForMember(u => u.Id, opt => opt.Ignore());


        }
    }
}
