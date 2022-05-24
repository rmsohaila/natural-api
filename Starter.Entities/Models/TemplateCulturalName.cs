using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class TemplateCulturalName : IEntity
	{
		[Key]
		public long Id { get; set; }

		[ForeignKey(nameof(Template))]
		public long TemplateId { get; set; }

		[ForeignKey(nameof(Language))]
		public long LanguageId { get; set; }

		public string Name { get; set; }

		public virtual Language Language { get; set; }
	}
}
