using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
    }
}
