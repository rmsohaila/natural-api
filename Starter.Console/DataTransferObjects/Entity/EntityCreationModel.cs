using Starter.Console.DTO.AttributeDataType;
using Starter.Console.DTO.Language;
using System.Collections.Generic;

namespace Starter.Console.DTO.Entity
{
    public class EntityCreationModel
    {
        public string Name { get; set; }

        public bool MarkForLabeling { get; set; }

        public long TemplateId { get; set; }

        public List<SlangModel> Slangs { get; set; }

        public List<EntityValueCreationModel> Values { get; set; }
    }

    public class EntityValueCreationModel
    {
        public string Value { get; set; }

        public long AttributeId { get; set; }

        public long LanguageId { get; set; }

        public long DataTypeId { get; set; }
    }
}
