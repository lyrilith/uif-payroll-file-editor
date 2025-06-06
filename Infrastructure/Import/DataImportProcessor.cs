using Core.Models;
using Core.ColumnDeclarations;

namespace Infrastructure.Import
{
	public static class DataImportProcessor
	{
		public class ImportResult
		{
			public List<Creator> Creators { get; set; } = new();
			public List<Employee> Employees { get; set; } = new();
			public List<Employer> Employers { get; set; } = new();
		}

		public static ImportResult ImportModelsFromCsv(string[] lines)
		{
			var creatorRows = new List<Dictionary<string, string>>();
			var employeeRows = new List<Dictionary<string, string>>();
			var employerRows = new List<Dictionary<string, string>>();

			int employerCount = 1;
			foreach (var line in lines)
			{
				var dict = ParseCsvLineToDict(line, employerCount);
				if (dict.Keys.Intersect(CreatorColumns.Columns.Select(c => c.Code)).Any())
					creatorRows.Add(dict);
				else if (dict.Keys.Intersect(EmployeeColumns.Columns.Select(c => c.Code)).Any())
					employeeRows.Add(dict);
				else if (dict.Keys.Intersect(EmployerColumns.Columns.Select(c => c.Code)).Any())
				{
					employerRows.Add(dict);
					employerCount++;
				}
			}

			var result = new ImportResult
			{
				Creators = creatorRows.Select(ToCreator).ToList(),
				Employees = employeeRows.Select(ToEmployee).ToList(),
				Employers = employerRows.Select(ToEmployer).ToList()
			};

			return result;
		}

		private static Creator ToCreator(Dictionary<string, string> rowDict)
		{
			var c = new Creator();
			foreach (var col in CreatorColumns.Columns)
			{
				if (rowDict.TryGetValue(col.Code, out var val))
				{
					switch (col.Name)
					{
						case nameof(Creator.CreatorUIFReferenceNo): c.CreatorUIFReferenceNo = val; break;
						case nameof(Creator.ContactPerson): c.ContactPerson = val; break;
						case nameof(Creator.ContactTelephoneNo): c.ContactTelephoneNo = val; break;
						case nameof(Creator.ContactEmailAddress): c.ContactEmailAddress = val; break;
						case nameof(Creator.PayrollMonth): c.PayrollMonth = ParseShortDate(val); break;
					}
				}
			}
			return c;
		}

		private static DateTime ParseShortDate(string dateString)
		{
			if (DateTime.TryParseExact(dateString, "yyyyMM", null, System.Globalization.DateTimeStyles.None, out var date))
			{
				return date;
			}
			return DateTime.Today;
		}

		private static Employee ToEmployee(Dictionary<string, string> rowDict)
		{
			var e = new Employee();
			foreach (var col in EmployeeColumns.Columns)
			{
				if (rowDict.TryGetValue(col.Code, out var val))
				{
					switch (col.Name)
					{
						case "EmployeeEmployerID":
							e.EmployerID = int.TryParse(val, out var id) ? id : 1;
							break;
						case nameof(Employee.EmployeeUIFReferenceNo): e.EmployeeUIFReferenceNo = val; break;
						case nameof(Employee.IDNumber): e.IDNumber = val; break;
						case nameof(Employee.OtherNumber): e.OtherNumber = val; break;
						case nameof(Employee.AlternateNumber): e.AlternateNumber = val; break;
						case nameof(Employee.Surname): e.Surname = val; break;
						case nameof(Employee.FirstNames): e.FirstNames = val; break;
						case nameof(Employee.DateOfBirth): e.DateOfBirth = val; break;
						case nameof(Employee.DateEmployedFrom): e.DateEmployedFrom = val; break;
						case nameof(Employee.DateEmployedTo): e.DateEmployedTo = val; break;
						case nameof(Employee.EmploymentStatus): e.EmploymentStatus = val; break;
						case nameof(Employee.ReasonForNonContribution): e.ReasonForNonContribution = val; break;
						case nameof(Employee.GrossTaxableRemuneration):
							e.GrossTaxableRemuneration = decimal.TryParse(val, out var gtr) ? gtr : 0;
							break;
						case nameof(Employee.RemunerationSubjectToUIF):
							e.RemunerationSubjectToUIF = decimal.TryParse(val, out var rsu) ? rsu : 0;
							break;
						case nameof(Employee.UIFContribution):
							e.UIFContribution = decimal.TryParse(val, out var uif) ? uif : 0;
							break;
						case nameof(Employee.BankBranchCode): e.BankBranchCode = val; break;
						case nameof(Employee.BankAccountNo): e.BankAccountNo = val; break;
						case nameof(Employee.BankAccountType): e.BankAccountType = val; break;
					}
				}
			}

			if (e.EmployerID == 0 && rowDict.TryGetValue("00", out var employerIDValue))
				e.EmployerID = int.TryParse(employerIDValue, out var id) ? id : 1;
			return e;
		}

		private static Employer ToEmployer(Dictionary<string, string> rowDict)
		{
			var em = new Employer();
			foreach (var col in EmployerColumns.Columns)
			{
				if (rowDict.TryGetValue(col.Code, out var val))
				{
					switch (col.Name)
					{
						case "EmployerID":
							em.EmployerID = int.TryParse(val, out var id) ? id : 1;
							break;
						case nameof(Employer.EmployerUIFReferenceNo): em.EmployerUIFReferenceNo = val; break;
						case nameof(Employer.PAYENumber): em.PAYENumber = val; break;
						case nameof(Employer.TotalGrossTaxableRemuneration):
							em.TotalGrossTaxableRemuneration = decimal.TryParse(val, out var tgtr) ? tgtr : 0;
							break;
						case nameof(Employer.TotalGrossRemunerationSubjectToUIF):
							em.TotalGrossRemunerationSubjectToUIF = decimal.TryParse(val, out var tgrsu) ? tgrsu : 0;
							break;
						case nameof(Employer.TotalContributions):
							em.TotalContributions = decimal.TryParse(val, out var tc) ? tc : 0;
							break;
						case nameof(Employer.TotalEmployees):
							em.TotalEmployees = int.TryParse(val, out var te) ? te : 0;
							break;
						case nameof(Employer.EmployerEmailAddress): em.EmployerEmailAddress = val; break;
					}
				}
			}
			if (em.EmployerID == 0 && rowDict.TryGetValue("00", out var employerIDValue))
				em.EmployerID = int.TryParse(employerIDValue, out var id) ? id : 1;
			return em;
		}

		private static Dictionary<string, string> ParseCsvLineToDict(string line, int employerCount)
		{
			var dict = new Dictionary<string, string>();
			var parts = SplitCsv(line);
			for (int i = 0; i + 1 < parts.Count; i += 2)
			{
				dict[parts[i]] = parts[i + 1];
			}
			dict["00"] = employerCount.ToString();
			return dict;
		}

		private static List<string> SplitCsv(string line)
		{
			var result = new List<string>();
			int i = 0;
			while (i < line.Length)
			{
				if (line[i] == '"')
				{
					int end = line.IndexOf('"', i + 1);
					result.Add(line.Substring(i + 1, end - i - 1));
					i = end + 1;
				}
				else
				{
					int end = line.IndexOf(',', i);
					if (end == -1) end = line.Length;
					result.Add(line.Substring(i, end - i));
					i = end;
				}
				if (i < line.Length && line[i] == ',') i++;
			}
			return result;
		}
	}
}
