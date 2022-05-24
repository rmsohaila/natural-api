using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Sample
{
    public class SampleLabelViewModel
    {
        public long Id { get; set; }

        // Foreign Key For Selected Type
        public long TypeId { get; set; }

        // Template / Entity	
        public string Type { get; set; }

        public int Start { get; set; }

        public int End { get; set; }
    }
}
