using AutoMapper;

namespace Starter.Console.MapperProfiles
{
    public class IntentProfile : Profile
    {
        public IntentProfile()
        {
            CreateMap<DTO.Intent.IntentCreationModel, Models.Intent>().ReverseMap();
            CreateMap<DTO.Intent.IntentModificationModel, Models.Intent>().ReverseMap();
            CreateMap<DTO.Intent.IntentViewModel, Models.Intent>().ReverseMap();
        }
    }
}
