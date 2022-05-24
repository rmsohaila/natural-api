using Starter.Console.DTO.AttributeDataType;
using System.Collections.Generic;

namespace Starter.Console.DTO.Template
{
    public class AttributeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool MarkEntityForLabeling { get; set; }
        public bool HasMultiValue { get; set; }
        
        public AttributeDataTypeViewModel DataType { get; set; }

        public IList<AttributeConfigurationViewModel> Values { get; set; }
    }
}
