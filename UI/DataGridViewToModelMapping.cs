using Core.Models;

namespace UI
{
	public static class DataGridViewToModelMapping
	{
		public static Creator GetCreatorFromFormFields(CreatorFormControls controls)
		{
			return new Creator
			{
				CreatorUIFReferenceNo = controls.UIFReferenceNoTextBox.Text ?? "",
				ContactPerson = controls.ContactPersonTextBox.Text ?? "",
				ContactTelephoneNo = controls.ContactTelephoneNoTextBox.Text ?? "",
				ContactEmailAddress = controls.ContactEmailAddressTextBox.Text ?? "",
				PayrollMonth = controls.PayrollMonthDatePicker.Value
			};
		}

		public static List<Employee> GetEmployeesFromGrid(DataGridView employeeDataGrid)
		{
			var employees = new List<Employee>();
			foreach (DataGridViewRow row in employeeDataGrid.Rows)
			{
				if (row.IsNewRow) continue;
				var employee = new Employee
				{
					EmployerID = int.TryParse(row.Cells["EmployeeEmployerID"].Value?.ToString() ?? "", out int id) ? id : 1,
					EmployeeUIFReferenceNo = row.Cells["EmployeeUIFReferenceNo"].Value?.ToString() ?? "",
					IDNumber = row.Cells["IDNumber"].Value?.ToString() ?? "",
					OtherNumber = row.Cells["OtherNumber"].Value?.ToString() ?? "",
					AlternateNumber = row.Cells["AlternateNumber"].Value?.ToString() ?? "",
					Surname = row.Cells["Surname"].Value?.ToString() ?? "",
					FirstNames = row.Cells["FirstNames"].Value?.ToString() ?? "",
					DateOfBirth = row.Cells["DateOfBirth"].Value?.ToString() ?? "",
					DateEmployedFrom = row.Cells["DateEmployedFrom"].Value?.ToString() ?? "",
					DateEmployedTo = row.Cells["DateEmployedTo"].Value?.ToString() ?? "",
					EmploymentStatus = row.Cells["EmploymentStatus"].Value?.ToString() ?? "",
					ReasonForNonContribution = row.Cells["ReasonForNonContribution"].Value?.ToString() ?? "",
					GrossTaxableRemuneration = decimal.TryParse(row.Cells["GrossTaxableRemuneration"].Value?.ToString(), out var gtr) ? gtr : 0,
					RemunerationSubjectToUIF = decimal.TryParse(row.Cells["RemunerationSubjectToUIF"].Value?.ToString(), out var rsu) ? rsu : 0,
					UIFContribution = decimal.TryParse(row.Cells["UIFContribution"].Value?.ToString(), out var uif) ? uif : 0,
					BankBranchCode = row.Cells["BankBranchCode"].Value?.ToString() ?? "",
					BankAccountNo = row.Cells["BankAccountNo"].Value?.ToString() ?? "",
					BankAccountType = row.Cells["BankAccountType"].Value?.ToString() ?? ""
				};
				employees.Add(employee);
			}
			return employees;
		}

		public static List<Employer> GetEmployersFromGrid(DataGridView employerDataGrid)
		{
			var employers = new List<Employer>();
			foreach (DataGridViewRow row in employerDataGrid.Rows)
			{
				if (row.IsNewRow) continue;
				var employer = new Employer
				{
					EmployerID = int.TryParse(row.Cells["EmployerID"].Value?.ToString() ?? "", out int id) ? id : 1,
					EmployerUIFReferenceNo = row.Cells["EmployerUIFReferenceNo"].Value?.ToString() ?? "",
					PAYENumber = row.Cells["PAYENumber"].Value?.ToString() ?? "",
					TotalGrossTaxableRemuneration = decimal.TryParse(row.Cells["TotalGrossTaxableRemuneration"].Value?.ToString(), out var tgtr) ? tgtr : 0,
					TotalGrossRemunerationSubjectToUIF = decimal.TryParse(row.Cells["TotalGrossRemunerationSubjectToUIF"].Value?.ToString(), out var tgrsu) ? tgrsu : 0,
					TotalContributions = decimal.TryParse(row.Cells["TotalContributions"].Value?.ToString(), out var tc) ? tc : 0,
					TotalEmployees = int.TryParse(row.Cells["TotalEmployees"].Value?.ToString(), out var te) ? te : 0,
					EmployerEmailAddress = row.Cells["EmployerEmailAddress"].Value?.ToString() ?? ""
				};
				employers.Add(employer);
			}
			return employers;
		}
	}
}