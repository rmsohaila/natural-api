using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Starter.Console.DTO.Template
{
    public class TemplateModificationModel
    {
        [Required]
        public string Name { get; set; }

        public IList<CulturalNameModel> LocalizedNames { get; set; }

        public bool MarkTemplateForLabeling { get; set; }

        public IList<AttributeModificationModel> Attributes { get; set; }
    }

    public class AttributeModificationModel {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool MarkEntityForLabeling { get; set; }
        public string DataType { get; set; }
        public bool HasMultiValue { get; set; }
        public IList<AttributeConfigurationViewModel> Values { get; set; }

        public bool IsNew { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
