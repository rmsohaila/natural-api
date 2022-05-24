namespace Starter.Models
{
    public class EntityValue
    {
        public long Id { get; set; }
		
        public long EntityId { get; set; }
        
        public long AttributeId { get; set; }

        public long LanguageId { get; set; }

        public long DataTypeId { get; set; }

        public string Value { get; set; }

        public Attribute Attribute { get; set; }
        public Language Language { get; set; }
        public AttributeDataType DataType { get; set; }

    }
}
