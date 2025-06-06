namespace Core.Models
{
	public class Creator
	{
		public string RecordType { get; set; } = "UICR";
		public string FormatType { get; set; } = "U1";
		public string VersionNo { get; set; } = "E03";
		public string CreatorUIFReferenceNo { get; set; } = string.Empty;
		public string TestLiveIndicator { get; set; } = "LIVE";
		public string ContactPerson { get; set; } = string.Empty;
		public string ContactTelephoneNo { get; set; } = string.Empty;
		public string ContactEmailAddress { get; set; } = string.Empty;
		public DateTime PayrollMonth { get; set; } = DateTime.Today;
	}
}
