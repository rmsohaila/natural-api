using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Entities.Models
{
    [Table("Table.Test.Masters")]
    public class Master
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Child> Childs { get; set; }
    }

    [Table("Table.Test.Childs")]
    public class Child
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }

        [ForeignKey(nameof(Master))]
        public int MasterId { get; set; }
    }
}
