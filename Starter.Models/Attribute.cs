using System;
using System.Collections.Generic;

namespace Starter.Models
{
    public class Attribute
    {
        public long Id { get; set; }

        public long TemplateId { get; set; }
        
        public long DataTypeId { get; set; }

        public string Name { get; set; }

        public bool MarkEntityForLabeling { get; set; }

        public bool IsNew { get; set; }

        public bool IsUpdated { get; set; }
        
        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public AttributeDataType DataType { get; set; }

        public IList<AttributeConfiguration> Values { get; set; }
    }
}
