using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Starter.Console.DTO.Template
{
    public class TemplateCreationModel
    {
        [Required]
        public string Name { get; set; }

        public IList<CulturalNameModel> LocalizedNames { get; set; }

        public bool MarkTemplateForLabeling { get; set; }

        public IList<AttributeCreationModel> Attributes { get; set; }
    }

    public class AttributeCreationModel
    {
        public string Name { get; set; }
        public bool MarkEntityForLabeling { get; set; }
        public long DataTypeId { get; set; }
        public bool HasMultiValue { get; set; }
        public IList<AttributeConfigurationCreationModel> Values { get; set; }
    }

    public class AttributeConfigurationCreationModel
    {
        public long LanguageId { get; set; }
        public string[] Value { get; set; }
    }
}
