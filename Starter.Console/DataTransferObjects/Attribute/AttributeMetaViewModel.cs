using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Attribute
{
    public class AttributeMetaViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool MarkForLabeling { get; set; }
    }
}
