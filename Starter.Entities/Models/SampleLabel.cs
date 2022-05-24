using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starter.Entities
{
	[Table("SampleTypes")]
	public class SampleLabel : IEntity
	{
		[Key]
		public long Id { get; set; }

		// Foreign Key For Selected Type
		[Required]
		public long TypeId { get; set; }
		
		// Template / Entity	
        [Required]
		public string Type { get; set; }

        [Required]
		public int WordStartIndex { get; set; }

        [Required]
		public int WordEndIndex { get; set; }
	}
}
