using AutoMapper;

namespace Starter.CORE.MapperProfiles
{
    public class IntentProfile : Profile
    {
        public IntentProfile()
        {
            CreateMap<Models.Intent, Entities.Intent>().ReverseMap();
        }
    }
}
