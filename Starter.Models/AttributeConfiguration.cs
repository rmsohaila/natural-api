namespace Starter.Models
{
    public class AttributeConfiguration
    {
        public long Id { get; set; }
        
        public long AttributeId { get; set; }

        public long LanguageId { get; set; }

        public Language Language { get; set; }

        public string Value { get; set; }
    }
}
