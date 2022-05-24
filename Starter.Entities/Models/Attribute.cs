using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class Attribute : IEntity, IAuditEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }

        [Required]
        [ForeignKey(nameof(AttributeDataType))]
        public long DataTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Type of data  (FreeText, DecimalNumber, NaturalNumber, Boolean, Date, Location)
        /// </summary>
        
        public bool MarkEntityForLabeling { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
        
        //[JsonIgnore]
        //public Template Template { get; set; }

        public AttributeDataType DataType { get; set; }

        public IList<AttributeConfiguration> Values { get; set; }
    }
}
