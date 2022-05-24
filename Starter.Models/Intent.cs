using System;

namespace Starter.Models
{
    public class Intent
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public long LastModifiedBy { get; set; }
        
        public DateTime LastModifiedOn { get; set; }
    }
}
