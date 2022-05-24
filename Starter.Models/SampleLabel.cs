namespace Starter.Models
{
	public class SampleLabel
	{
        public long Id { get; set; }

		public long TypeId { get; set; }
		
		public string Type { get; set; }

		public int WordStartIndex { get; set; }

		public int WordEndIndex { get; set; }
	}
}
