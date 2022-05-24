using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Entities
{
    public interface IAuditEntity
    {
        long CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        long LastModifiedBy { get; set; }
        DateTime LastModifiedOn { get; set; }
    }
}
