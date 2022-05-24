using AutoMapper;

namespace Starter.Console.MapperProfiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<DTO.Language.LanguageCreationModel, Models.Language>().ReverseMap();
            CreateMap<DTO.Language.LanguageModificationModel, Models.Language>().ReverseMap();
            CreateMap<DTO.Language.LanguageViewModel, Models.Language>().ReverseMap();
        }
    }
}
