namespace Starter.Models
{
    public class TemplateCulturalName
	{
		public long Id { get; set; }

		public long TemplateId { get; set; }

		public long LanguageId { get; set; }

		public string Name { get; set; }
	}
}
