using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class AttributeConfiguration: IEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Attribute))]
        public long AttributeId { get; set; }

        [ForeignKey(nameof(Language))]
        public long LanguageId { get; set; }

        [Required]
        public string Value { get; set; }

        public Language Language { get; set; }
    }
}
