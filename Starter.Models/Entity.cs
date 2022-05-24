using System;
using System.Collections.Generic;

namespace Starter.Models
{
    public class Entity
    {
        public long Id { get; set; }

        public long TemplateId { get; set; }
        
        public string Name { get; set; }
        
        public bool MarkForLabeling { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public IList<EntityCulturalName> Names { get; set; }

        public IList<EntityValue> Values { get; set; }

        public Template Template { get; set; }
    }
}
