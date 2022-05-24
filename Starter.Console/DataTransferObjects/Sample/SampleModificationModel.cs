using Starter.Console.DTO.Intent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Sample
{
    public class SampleModificationModel
    {
        public string Sample { get; set; }

        public long IntentId { get; set; }

        public List<SampleLabelViewModel> Labels { get; set; }
    }
}
