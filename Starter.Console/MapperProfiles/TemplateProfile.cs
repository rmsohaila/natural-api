using AutoMapper;
using Starter.Console.DTO;
using Starter.Console.DTO.Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Starter.Console.MapperProfiles
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<Models.AttributeDataType, DTO.AttributeDataType.AttributeDataTypeViewModel>().ReverseMap();
            // To map creation model
            CreateMap<DTO.Template.TemplateCreationModel, Models.Template>()
                .ForMember(p => p.Attributes, options => options.MapFrom(MapAttributesFromDTO))
                .ForMember(p => p.CulturalNames, options => options.MapFrom(MapCulturalNamesFromDTO));

            // To map view model
            CreateMap<Models.Template, DTO.Template.TemplateViewModel>()
                .ForMember(p => p.CreatedBy, options => options.MapFrom(MapAuditUser))
                .ForMember(p => p.LastModifiedBy, options => options.MapFrom(MapAuditUser))
                .ForMember(p => p.Attributes, options => options.MapFrom(MapAttributesFromModel))
                .ForMember(p => p.LocalizedNames, options => options.MapFrom(MapCulturalNamesFromModel));

            CreateMap<Models.Template, DTO.Template.TemplateListIndexModel>()
                .ForMember(p => p.AttributeCount, options => options.MapFrom(src => src.Attributes.Count))
                .ForMember(p => p.EntityCount, options => options.MapFrom(src => src.Entities.Count))
                .ForMember(p => p.LanguageCount, options => options.MapFrom(src => src.CulturalNames.Count));

            // To map attributes for entities
            CreateMap<Models.Attribute, DTO.Template.AttributeViewModel>()
                .ForMember(p => p.Values, options => options.MapFrom(MapAttributeValuesFromModel));

        }

        #region From Data Transfer Object To Models

        private List<Models.TemplateCulturalName> MapCulturalNamesFromDTO(
            DTO.Template.TemplateCreationModel creationModel, Models.Template template)
        {
            var result = new List<Models.TemplateCulturalName>();

            if (creationModel.LocalizedNames == null) { return result; }
            foreach (var _name in creationModel.LocalizedNames)
            {
                result.Add(new Models.TemplateCulturalName()
                {
                    Name = _name.Name.Trim(),
                    LanguageId = _name.LanguageId
                });
            }
            return result;
        }

        private List<Models.Attribute> MapAttributesFromDTO(
        DTO.Template.TemplateCreationModel creationModel, Models.Template template)
        {
            var result = new List<Models.Attribute>();

            if (creationModel.Attributes == null) { return result; }

            foreach (var _attr in creationModel.Attributes)
            {
                result.Add(new Models.Attribute()
                {
                    DataTypeId = _attr.DataTypeId,
                    MarkEntityForLabeling = _attr.MarkEntityForLabeling,
                    Name = _attr.Name,
                    Values = this.MapAttributeValuesFromDTO(_attr.Values)
                });
            }

            return result;
        }

        public List<Models.AttributeConfiguration> MapAttributeValuesFromDTO(IList<DTO.Template.AttributeConfigurationCreationModel> attributeValues)
        {
            var result = new List<Models.AttributeConfiguration>();
            if (attributeValues == null) { return result; }

            foreach (var av in attributeValues)
            {
                foreach (var v in av.Value)
                {
                    result.Add(new Models.AttributeConfiguration()
                    {
                        LanguageId = av.LanguageId,
                        Value = v.Trim()
                    });
                }
            }

            return result;
        }

        #endregion

        #region From Models To Data Transfer Object
        private List<DTO.Template.CulturalNameModel> MapCulturalNamesFromModel(
           Models.Template template, DTO.Template.TemplateViewModel viewModel)
        {
            var result = new List<DTO.Template.CulturalNameModel>();

            if (template.CulturalNames == null) { return result; }

            foreach (var _name in template.CulturalNames)
            {
                result.Add(new DTO.Template.CulturalNameModel()
                {
                    Name = _name.Name.Trim(),
                    LanguageId = _name.LanguageId
                });
            }
            return result;
        }

        private List<DTO.Template.AttributeViewModel> MapAttributesFromModel(
            Models.Template template, DTO.Template.TemplateViewModel viewModel)
        {
            var result = new List<DTO.Template.AttributeViewModel>();

            if (template.Attributes == null) { return result; }

            foreach (var _attr in template.Attributes)
            {
                result.Add(new DTO.Template.AttributeViewModel()
                {
                    Id = _attr.Id,
                    MarkEntityForLabeling = _attr.MarkEntityForLabeling,
                    Name = _attr.Name,
                    Values = MapAttributeValuesFromModel(_attr.Values)
                });
            }

            return result;
        }

        public List<DTO.Template.AttributeConfigurationViewModel> MapAttributeValuesFromModel
            (IList<Models.AttributeConfiguration> attributeValues)
        {
            var result = new List<DTO.Template.AttributeConfigurationViewModel>();

            if (attributeValues == null) { return result; }
            var attributeGroup = attributeValues.GroupBy(p => p.AttributeId);
            foreach (var ag in attributeGroup)
            {
                foreach (var lg in ag.GroupBy(p => p.LanguageId))
                {
                    var _values = new ArrayList();
                    var newAttributeConfiguration = new DTO.Template.AttributeConfigurationViewModel()
                    {
                        LanguageId = lg.Key
                    };
                    foreach (var item in lg)
                        _values.Add(item.Value.Trim());

                    newAttributeConfiguration.Value = (string[])_values.ToArray(typeof(string));
                    result.Add(newAttributeConfiguration);
                }
            }

            return result;
        }

        public List<DTO.Template.AttributeConfigurationViewModel> MapAttributeValuesFromModel
            (Models.Attribute modelAttributes, DTO.Template.AttributeViewModel attributeViewModel)
        {
            var result = new List<DTO.Template.AttributeConfigurationViewModel>();

            if (modelAttributes == null) { return result; }

            var attributeGroup = modelAttributes.Values.GroupBy(p => p.AttributeId);
            foreach (var ag in attributeGroup)
            {
                foreach (var lg in ag.GroupBy(p => p.LanguageId))
                {
                    var _values = new ArrayList();
                    var newAttributeConfiguration = new DTO.Template.AttributeConfigurationViewModel()
                    {
                        LanguageId = lg.Key
                    };
                    foreach (var item in lg)
                        _values.Add(item.Value.Trim());

                    newAttributeConfiguration.Value = (string[])_values.ToArray(typeof(string));
                    result.Add(newAttributeConfiguration);
                }
            }
            return result;
        }
        #endregion

        #region Map Audit Properties
        private AuditUserView MapAuditUser(Models.Template template, DTO.Template.TemplateViewModel viewModel)
        {
            var user = new AuditUserView();
            user.Id = template.CreatedBy;
            return user;
        }
        #endregion
    }
}