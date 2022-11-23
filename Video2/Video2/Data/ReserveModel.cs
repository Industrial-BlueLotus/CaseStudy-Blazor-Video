namespace Video2.Data
{
	public class ReserveModel
	{

		public int Cid { get; set; }
		public int Vid { get; set; }

		public DateTime? StartDate { get; set; }= DateTime.Today;
		public DateTime? DueDate { get; set; } = DateTime.Today;
	}
}
