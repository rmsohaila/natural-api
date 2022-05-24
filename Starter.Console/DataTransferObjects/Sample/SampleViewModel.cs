using Starter.Console.DTO.Intent;
using System.Collections.Generic;

namespace Starter.Console.DTO.Sample
{
    public class SampleViewModel
    {
        public long Id { get; set; }

        public string Sample { get; set; }

        public List<SampleLabelViewModel> Labels { get; set; }

        public IntentViewModel Intent { get; set; }
    }
}
