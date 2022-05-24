using System;
using System.Collections.Generic;

namespace Starter.Models
{
    public class Template
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public bool MarkForLabeling { get; set; }

		public long CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public long LastModifiedBy { get; set; }

		public DateTime LastModifiedOn { get; set; }

		public virtual IList<TemplateCulturalName> CulturalNames { get; set; }

		public virtual IList<Attribute> Attributes { get; set; }

		public virtual IList<Entity> Entities { get; set; }
	}
}
