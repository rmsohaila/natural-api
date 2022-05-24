using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Entity
{
    public class EntityViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool MarkForLabeling { get; set; }


        public List<EntityCulturalNamesViewModel> Names { get; set; }

        public List<EntityValueViewModel> Values { get; set; }
    }
}
