using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Entity
{
    public class EntityUpdationModel
    {
        public string Name { get; set; }

        public List<Lookup> CulturalNames { get; set; }

        public List<EntityValueViewModel> Values { get; set; }
    }
}
