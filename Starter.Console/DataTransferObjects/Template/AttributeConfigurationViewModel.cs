using Starter.Console.DTO.Language;

namespace Starter.Console.DTO.Template
{
    public class AttributeConfigurationViewModel
    {
        public long LanguageId { get; set; }
        public LanguageViewModel Language { get; set; }
        public string[] Value { get; set; }
    }
}
