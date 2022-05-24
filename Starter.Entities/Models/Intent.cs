
using System;
using System.ComponentModel.DataAnnotations;

namespace Starter.Entities
{
	public class Intent : IEntity, IAuditEntity
	{
		[Key]
		public long Id { get; set; }

		public string Name { get; set; }

        public long CreatedBy { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public long LastModifiedBy { get ; set ; }
        public DateTime LastModifiedOn { get ; set ; }
    }
}
