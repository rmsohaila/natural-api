using AutoMapper;

namespace Starter.CORE.MapperProfiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Models.Language, Entities.Language>().ReverseMap();
        }
    }
}
