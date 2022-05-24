namespace Starter.Models
{
    public class EntityCulturalName
	{
		public long Id { get; set; }

		public long EntityId { get; set; }

		public long LanguageId { get; set; }

		public string Name { get; set; }

		public Language Language { get; set; }
	}
}
