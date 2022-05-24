using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Models
{
    public class AttributeDataType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string DBType { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
