using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Template
{
    public class TemplateListIndexModel
    {
        public long Id { get; set; }
        public string  Name { get; set; }
        public int AttributeCount { get; set; }
        public int EntityCount { get; set; }
        public int LanguageCount { get; set; }
    }
}
