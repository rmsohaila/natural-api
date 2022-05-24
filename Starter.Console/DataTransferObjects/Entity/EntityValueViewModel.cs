using Starter.Console.DTO.Attribute;
using Starter.Console.DTO.AttributeDataType;
using Starter.Console.DTO.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Entity
{
    public class EntityValueViewModel
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public AttributeMetaViewModel Attribute { get; set; }

        public SlangModel Language { get; set; }

        public AttributeDataTypeViewModel DataType { get; set; }
    }
}
