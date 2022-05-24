using System;
using System.ComponentModel.DataAnnotations;

namespace Starter.Entities
{
    public class Language : IEntity, IAuditEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(5)]
        public string ISOCODE { get; set; }

        public long CreatedBy { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public long LastModifiedBy { get ; set ; }
        public DateTime LastModifiedOn { get ; set ; }
    }
}
