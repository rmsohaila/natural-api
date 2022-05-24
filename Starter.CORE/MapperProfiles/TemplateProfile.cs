using System;
using AutoMapper;
using System.Collections.Generic;

namespace Starter.CORE.MapperProfiles
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<Models.AttributeDataType, Entities.AttributeDataType>().ReverseMap();

            CreateMap<Models.TemplateCulturalName, Entities.TemplateCulturalName>()
                .ForMember(dst => dst.Language, src => src.Ignore())
                .ReverseMap();

            CreateMap<Models.EntityCulturalName, Entities.EntityCulturalName>()
                .ForMember(dst => dst.Language, src => src.Ignore())
                .ReverseMap();

            CreateMap<Models.Template, Entities.Template>()
                .ForMember(dst => dst.Attributes, src => src.MapFrom(MapAttributesFromModel))
                .ForMember(dst => dst.CulturalNames, src => src.MapFrom(MapCulturalNamesFromModel));

            CreateMap<Entities.Template, Models.Template>()
                .ForMember(dst => dst.Attributes, src => src.MapFrom(MapAttributesFromEntities))
                .ForMember(dst => dst.CulturalNames, src => src.MapFrom(MapCulturalNamesFromEntities));

            CreateMap<Entities.Template, Models.Template>()
                .ForMember(dst => dst.Attributes, src => src.MapFrom(src => src.Attributes))
                .ForMember(dst => dst.CulturalNames, src => src.MapFrom(src => src.CulturalNames));

            // For attributes only
            CreateMap<Entities.AttributeConfiguration, Models.AttributeConfiguration>()
                .ForMember(dst => dst.Language, src => src.MapFrom((src, dst, _, context) => src.Language))
                .ReverseMap();

            CreateMap<Entities.Attribute, Models.Attribute>()
                .ForMember(dst => dst.Values, src => src.MapFrom(
                    (src, dst, _, context) => MapAttributeValuesFromEntities(src, dst, context)));
        }

        #region From Models To Entities

        private List<Entities.TemplateCulturalName> MapCulturalNamesFromModel(
            Models.Template modelTemplate, Entities.Template entityTemplate)
        {
            var result = new List<Entities.TemplateCulturalName>();
            if (modelTemplate.CulturalNames == null) { return result; }

            foreach (var name in modelTemplate.CulturalNames)
            {
                result.Add(new Entities.TemplateCulturalName()
                {
                    LanguageId = name.LanguageId,
                    Name = name.Name.Trim()
                });
            }

            return result;
        }

        private List<Entities.Attribute> MapAttributesFromModel(
            Models.Template modelTemplate, Entities.Template entityTemplate)
        {
            var result = new List<Entities.Attribute>();

            if (modelTemplate.Attributes == null) { return result; }

            foreach (var _attr in modelTemplate.Attributes)
            {
                var newAttr = new Entities.Attribute()
                {
                    DataTypeId = _attr.DataTypeId,
                    MarkEntityForLabeling = _attr.MarkEntityForLabeling,
                    Name = _attr.Name,
                    CreatedOn = DateTime.UtcNow,
                    Values = this.MapAttributeValuesFromModel(_attr.Values)
                };
                if (_attr.CreatedBy > 0)
                    newAttr.CreatedBy = _attr.CreatedBy;
                if (_attr.LastModifiedBy > 0)
                    newAttr.LastModifiedBy = _attr.LastModifiedBy;

                result.Add(newAttr);
            }

            return result;
        }

        public List<Entities.AttributeConfiguration> MapAttributeValuesFromModel(IList<Models.AttributeConfiguration> attributeValues)
        {
            var result = new List<Entities.AttributeConfiguration>();
            if (attributeValues == null) { return result; }

            foreach (var av in attributeValues)
            {
                result.Add(new Entities.AttributeConfiguration()
                {
                    LanguageId = av.LanguageId,
                    Value = av.Value
                });
            }

            return result;
        }

        #endregion

        #region From Entities To Models
        private List<Models.TemplateCulturalName> MapCulturalNamesFromEntities(
            Entities.Template entityTemplate, Models.Template modelTemplate)
        {
            var result = new List<Models.TemplateCulturalName>();
            if (entityTemplate.CulturalNames == null) { return result; }

            foreach (var name in entityTemplate.CulturalNames)
            {
                result.Add(new Models.TemplateCulturalName()
                {
                    Id = name.Id,
                    Name = name.Name.Trim(),
                    LanguageId = name.LanguageId,
                    TemplateId = name.TemplateId
                });
            }

            return result;
        }

        private List<Models.Attribute> MapAttributesFromEntities(
            Entities.Template entityTemplate, Models.Template modelTemplate)
        {
            var result = new List<Models.Attribute>();

            if (entityTemplate.Attributes == null) { return result; }

            foreach (var _attr in entityTemplate.Attributes)
            {
                var newAttr = new Models.Attribute()
                {
                    Id = _attr.Id,
                    Name = _attr.Name,
                    DataTypeId = _attr.DataTypeId,
                    MarkEntityForLabeling = _attr.MarkEntityForLabeling,
                    TemplateId = _attr.TemplateId,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = _attr.CreatedBy,
                    LastModifiedBy = _attr.LastModifiedBy,
                    LastModifiedOn = _attr.LastModifiedOn,
                    Values = this.MapAttributeValuesFromEntities(_attr.Values)
                };

                result.Add(newAttr);
            }

            return result;
        }

        public List<Models.AttributeConfiguration> MapAttributeValuesFromEntities
            (IList<Entities.AttributeConfiguration> attributeValues)
        {
            var result = new List<Models.AttributeConfiguration>();
            if (attributeValues == null) { return result; }

            foreach (var av in attributeValues)
            {
                result.Add(new Models.AttributeConfiguration()
                {
                    Id = av.Id,
                    Value = av.Value,
                    AttributeId = av.AttributeId,
                    LanguageId = av.LanguageId,
                });
            }

            return result;
        }

        public List<Models.AttributeConfiguration> MapAttributeValuesFromEntities
            (Entities.Attribute entityAttribute, Models.Attribute modelAttributes, ResolutionContext context)
        {
            return context.Mapper.Map<List<Models.AttributeConfiguration>>(entityAttribute.Values);

            //var result = new List<Models.AttributeConfiguration>();
            //if (entityAttribute.Values == null) { return result; }

            //foreach (var av in entityAttribute.Values)
            //{
            //    result.Add(new Models.AttributeConfiguration()
            //    {
            //        Id = av.Id,
            //        Value = av.Value,
            //        AttributeId = av.AttributeId,
            //        LanguageId = av.LanguageId,
            //    });
            //}

            //return result;
        }

        #endregion
    }
}
