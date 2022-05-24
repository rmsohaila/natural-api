using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class EntityValue : IEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Entity))]
        public long EntityId { get; set; }
        
		[ForeignKey(nameof(Attribute))]
        public long AttributeId { get; set; }

        [ForeignKey(nameof(AttributeDataType))]
        public long DataTypeId { get; set; }

        [ForeignKey(nameof(Language))]
        public long LanguageId { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual AttributeDataType DataType { get; set; }
        public virtual Language Language { get; set; }
        public Attribute Attribute { get; set; }
    }
}
