
using System;

namespace Starter.Entities
{
    public class AttributeDataType : IEntity, IAuditEntity
    {
        public long Id { get ; set ; }

        public string Name { get; set; }

        public string DBType { get; set; }

        public long CreatedBy { get ; set ; }

        public DateTime CreatedOn { get ; set ; }

        public long LastModifiedBy { get ; set ; }

        public DateTime LastModifiedOn { get ; set ; }
    }
}
