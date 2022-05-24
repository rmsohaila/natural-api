using Starter.Console.DTO.Intent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Sample
{
    public class SampleCreationModel
    {
        public string Sample { get; set; }

        public long IntentId { get; set; }

        public List<SampleLabelCreationModel> Labels { get; set; }
    }

    public class SampleLabelCreationModel
    {
        public long TypeId { get; set; }

        public string Type { get; set; }

        public int Start { get; set; }
        
        public int End { get; set; }

    }
}
