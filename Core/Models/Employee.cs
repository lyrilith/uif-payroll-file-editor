namespace Core.Models
{
	public class Employee
	{
		public int EmployerID { get; set; }
		public string RecordType { get; set; } = "UIWK";
		public string EmployeeUIFReferenceNo { get; set; } = string.Empty;
		public string IDNumber { get; set; } = string.Empty;
		public string OtherNumber { get; set; } = string.Empty;
		public string AlternateNumber { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string FirstNames { get; set; } = string.Empty;
		public string DateOfBirth { get; set; } = string.Empty; // Format: yyyyMMdd
		public string DateEmployedFrom { get; set; } = string.Empty; // Format: yyyyMMdd
		public string DateEmployedTo { get; set; } = string.Empty; // Format: yyyyMMdd
		public string EmploymentStatus { get; set; } = string.Empty;
		public string ReasonForNonContribution { get; set; } = string.Empty;
		public decimal GrossTaxableRemuneration { get; set; }
		public decimal RemunerationSubjectToUIF { get; set; }
		public decimal UIFContribution { get; set; }
		public string BankBranchCode { get; set; } = string.Empty;
		public string BankAccountNo { get; set; } = string.Empty;
		public string BankAccountType { get; set; } = string.Empty;
	}
}
