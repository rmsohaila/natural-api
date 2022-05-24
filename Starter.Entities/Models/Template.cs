using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Starter.Entities
{
    public class Template : IEntity, IAuditEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool MarkForLabeling { get; set; }

        public long CreatedBy { get; set; }
        
        public System.DateTime CreatedOn { get; set; }
        
        public long LastModifiedBy { get; set; }
        
        public System.DateTime LastModifiedOn { get; set; }

        public IList<TemplateCulturalName> CulturalNames { get; set; }

        public IList<Attribute> Attributes { get; set; }

        public IList<Entity> Entities { get; set; }

    }
}
