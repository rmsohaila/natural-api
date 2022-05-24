
using AutoMapper;

namespace Starter.Console.MapperProfiles
{
    public class AttributeDataTypeProfile : Profile
    {
        public AttributeDataTypeProfile()
        {
            CreateMap<DTO.AttributeDataType.AttributeDataTypeCreationModel, Models.AttributeDataType>().ReverseMap();
        }
    }
}
