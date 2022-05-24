using AutoMapper;
using System.Collections.Generic;

namespace Starter.Console.MapperProfiles
{
    public class EntityProfile : Profile
    {

        public EntityProfile()
        {
            CreateMap<DTO.Attribute.AttributeMetaViewModel, Models.Attribute>();

            CreateMap<DTO.Entity.EntityValueCreationModel, Models.EntityValue>().ReverseMap();

            CreateMap<DTO.Entity.EntityCreationModel, Models.Entity>()
                .ForMember(dst => dst.Names, src => src.MapFrom(MapCulturalNamesFromDTO));

            CreateMap<Models.Entity, DTO.Entity.EntityViewModel>()
                .ForMember(dst => dst.Names, src => src.MapFrom(MapCulturalNamesFromModel))
                .ForMember(dst => dst.Values, src => src.MapFrom(MapValuesNestedPropertyFromModel));

            CreateMap<Models.Entity, DTO.Entity.EntityListViewModel>()
                .ForMember(dst => dst.TemplateName, src => src.MapFrom(src => src.Template.Name));
        }

        #region From Data Transfer Object To Models
        private List<Models.EntityCulturalName> MapCulturalNamesFromDTO(
            DTO.Entity.EntityCreationModel source, Models.Entity destination)
        {
            var result = new List<Models.EntityCulturalName>();

            if (source.Slangs == null) { return result; }
            foreach (var slang in source.Slangs)
            {
                result.Add(new Models.EntityCulturalName()
                {
                    Name = slang.Value.Trim(),
                    LanguageId = slang.LanguageId
                });
            }
            return result;
        }
        #endregion

        #region From Models to Data Transfer Object
        private List<DTO.Entity.EntityCulturalNamesViewModel> MapCulturalNamesFromModel(
           Models.Entity source, DTO.Entity.EntityViewModel destination)
        {
            var result = new List<DTO.Entity.EntityCulturalNamesViewModel>();

            if (source.Names == null) { return result; }
            foreach (var slang in source.Names)
            {
                result.Add(new DTO.Entity.EntityCulturalNamesViewModel()
                {
                    Value = slang.Name.Trim(),
                    Language = new DTO.Language.SlangModel()
                    {
                        LanguageId = slang.LanguageId,
                        Value = slang.Language.ISOCODE
                    }
                });
            }
            return result;
        }

        private List<DTO.Entity.EntityValueViewModel> MapValuesNestedPropertyFromModel(
            Models.Entity source, DTO.Entity.EntityViewModel destination)
        {
            var result = new List<DTO.Entity.EntityValueViewModel>();
            foreach (var value in source.Values)
            {
                result.Add(new DTO.Entity.EntityValueViewModel()
                {
                    Id = value.Id,
                    DataType = this.MapDataTypeFromModel(value.DataType),
                    Language = this.MapDataTypeFromModel(value.Language),
                    Value = value.Value
                });
            }
            return result;
        }

        private DTO.AttributeDataType.AttributeDataTypeViewModel MapDataTypeFromModel(Models.AttributeDataType source)
        {
            return new DTO.AttributeDataType.AttributeDataTypeViewModel()
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        private DTO.Language.SlangModel MapDataTypeFromModel(Models.Language source)
        {
            return new DTO.Language.SlangModel()
            {
                LanguageId = source.Id,
                Value = source.ISOCODE
            };
        }

        #endregion
    }
}
