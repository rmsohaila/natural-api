
using AutoMapper;

namespace Starter.CORE.MapperProfiles
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<Entities.SampleLabel, Models.SampleLabel>();

            CreateMap<Entities.Sample, Models.Sample>();


            CreateMap<Models.Intent, Entities.Intent>()
                .ReverseMap();

            CreateMap<Models.SampleLabel, Entities.SampleLabel>()
                .ReverseMap();

            CreateMap<Models.Sample, Entities.Sample>()
                .ReverseMap();
        }
    }
}
