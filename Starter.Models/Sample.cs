using System;
using System.Collections.Generic;

namespace Starter.Models
{
    public class Sample
    {
        public long Id { get; set; }

        public long IntentId { get; set; }

        public string Text { get; set; }

        public Intent Intent { get; set; }

        public IList<SampleLabel> Labels { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
