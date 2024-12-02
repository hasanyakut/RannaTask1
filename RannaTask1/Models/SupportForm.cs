namespace RannaTask1.Models
{
	public class SupportForm
	{
		public int Id { get; set; }
		public string Subject { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; }
		public string Status { get; set; } = "Pending";
	}
}
