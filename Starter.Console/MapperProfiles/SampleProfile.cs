
using AutoMapper;

namespace Starter.Console.MapperProfiles
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<DTO.Sample.SampleLabelViewModel, Models.SampleLabel>()
               .ReverseMap();

            CreateMap<Models.Sample, DTO.Sample.SampleViewModel>()
                .ForMember(dst => dst.Sample, src => src.MapFrom(src => src.Text));

            CreateMap<Models.Sample, DTO.Sample.SampleListViewModel>()
                .ForMember(dst => dst.Sample, src => src.MapFrom(src => src.Text));

            CreateMap<DTO.Sample.SampleListViewModel, Models.Sample>()
                .ForMember(dst => dst.Text, src => src.MapFrom(src => src.Sample));

            CreateMap<DTO.Sample.SampleLabelCreationModel, Models.SampleLabel>()
                .ForMember(dst => dst.WordStartIndex, src => src.MapFrom(src => src.Start))
                .ForMember(dst => dst.WordEndIndex, src => src.MapFrom(src => src.End));

            CreateMap<DTO.Sample.SampleCreationModel, Models.Sample>()
                .ForMember(dst => dst.Text, src => src.MapFrom(src => src.Sample));
        }
    }
}
