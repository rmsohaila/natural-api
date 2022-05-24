using System;
using System.Collections.Generic;

namespace Starter.Console.DTO.Template
{
    public class TemplateViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IList<CulturalNameModel> LocalizedNames { get; set; }

        public bool MarkTemplateForLabeling { get; set; }

        public IList<AttributeViewModel> Attributes { get; set; }

        public AuditUserView CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public AuditUserView LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
