namespace Core.Models
{
	public class Employer
	{
		public int EmployerID { get; set; }
		public string RecordType { get; set; } = "UIEM";
		public string EmployerUIFReferenceNo { get; set; } = string.Empty;
		public string PAYENumber { get; set; } = string.Empty;
		public decimal TotalGrossTaxableRemuneration { get; set; }
		public decimal TotalGrossRemunerationSubjectToUIF { get; set; }
		public decimal TotalContributions { get; set; }
		public int TotalEmployees { get; set; }
		public string EmployerEmailAddress { get; set; } = string.Empty;
	}
}
