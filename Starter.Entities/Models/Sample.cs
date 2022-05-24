using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class Sample : IEntity, IAuditEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Attribute))]
        public long IntentId { get; set; }

        [Required]
        public string Text { get; set; }

        public Intent Intent { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long LastModifiedBy { get; set; }
        public System.DateTime LastModifiedOn { get; set; }

        public IList<SampleLabel> Labels { get; set; }
    }
}
