using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class Entity : IEntity, IAuditEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool MarkForLabeling { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public Template Template { get; set; }

        public IList<EntityCulturalName> Names { get; set; }
        
        public IList<EntityValue> Values { get; set; }
    }
}
