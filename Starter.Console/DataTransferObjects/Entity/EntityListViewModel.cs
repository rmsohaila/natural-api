using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Entity
{
    public class EntityListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool MarkForLabeling { get; set; }

        public string TemplateName { get; set; }
    }
}
