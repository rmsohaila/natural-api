using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
    public class EntityCulturalName : IEntity
	{
		[Key]
		public long Id { get; set; }

		[ForeignKey(nameof(Entity))]
		public long EntityId { get; set; }

		[ForeignKey(nameof(Language))]
		public long LanguageId { get; set; }

		public string Name { get; set; }

		public virtual Language Language { get; set; }
	}
}
