using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.DTO.Sample
{
    public class SampleListViewModel
    {
        public long Id { get; set; }

        public string Sample { get; set; }

        public IList<DTO.Sample.SampleLabelViewModel> Labels { get; set; }
    }
}
