using Core.Models;

namespace UI
{
	public static class ModelToDataGridViewMapping
	{
		public static void PopulateCreatorFields(CreatorFormControls controls, IEnumerable<Creator> creators)
		{
			if (creators == null || !creators.Any())
			{
				controls.UIFReferenceNoTextBox.Text = string.Empty;
				controls.ContactPersonTextBox.Text = string.Empty;
				controls.ContactTelephoneNoTextBox.Text = string.Empty;
				controls.ContactEmailAddressTextBox.Text = string.Empty;
				controls.PayrollMonthDatePicker.Value = DateTime.Today;
				return;
			}

			var creator = creators.First();
			controls.UIFReferenceNoTextBox.Text = creator.CreatorUIFReferenceNo;
			controls.ContactPersonTextBox.Text = creator.ContactPerson;
			controls.ContactTelephoneNoTextBox.Text = creator.ContactTelephoneNo;
			controls.ContactEmailAddressTextBox.Text = creator.ContactEmailAddress;
			controls.PayrollMonthDatePicker.Value = creator.PayrollMonth;
		}

		public static void PopulateEmployeeGrid(DataGridView employeeDataGrid, IEnumerable<Employee> employees)
		{
			employeeDataGrid.Rows.Clear();
			foreach (var employee in employees)
			{
				int idx = employeeDataGrid.Rows.Add();
				var row = employeeDataGrid.Rows[idx];
				row.Cells["EmployeeEmployerID"].Value = employee.EmployerID;
				row.Cells["EmployeeUIFReferenceNo"].Value = employee.EmployeeUIFReferenceNo;
				row.Cells["IDNumber"].Value = employee.IDNumber;
				row.Cells["OtherNumber"].Value = employee.OtherNumber;
				row.Cells["AlternateNumber"].Value = employee.AlternateNumber;
				row.Cells["Surname"].Value = employee.Surname;
				row.Cells["FirstNames"].Value = employee.FirstNames;
				row.Cells["DateOfBirth"].Value = employee.DateOfBirth?.ToString("yyyy-MM-dd") ?? "";
				row.Cells["DateEmployedFrom"].Value = employee.DateEmployedFrom?.ToString("yyyy-MM-dd") ?? "";
				row.Cells["DateEmployedTo"].Value = employee.DateEmployedTo?.ToString("yyyy-MM-dd") ?? "";
				row.Cells["EmploymentStatus"].Value = employee.EmploymentStatus;
				row.Cells["ReasonForNonContribution"].Value = employee.ReasonForNonContribution;
				row.Cells["GrossTaxableRemuneration"].Value = employee.GrossTaxableRemuneration;
				row.Cells["RemunerationSubjectToUIF"].Value = employee.RemunerationSubjectToUIF;
				row.Cells["UIFContribution"].Value = employee.UIFContribution;
				row.Cells["BankBranchCode"].Value = employee.BankBranchCode;
				row.Cells["BankAccountNo"].Value = employee.BankAccountNo;
				row.Cells["BankAccountType"].Value = employee.BankAccountType;
			}
		}

		public static void PopulateEmployerGrid(DataGridView employerDataGrid, IEnumerable<Employer> employers)
		{
			employerDataGrid.Rows.Clear();
			foreach (var employer in employers)
			{
				int idx = employerDataGrid.Rows.Add();
				var row = employerDataGrid.Rows[idx];
				row.Cells["EmployerID"].Value = employer.EmployerID;
				row.Cells["EmployerUIFReferenceNo"].Value = employer.EmployerUIFReferenceNo;
				row.Cells["PAYENumber"].Value = employer.PAYENumber;
				row.Cells["TotalGrossTaxableRemuneration"].Value = employer.TotalGrossTaxableRemuneration;
				row.Cells["TotalGrossRemunerationSubjectToUIF"].Value = employer.TotalGrossRemunerationSubjectToUIF;
				row.Cells["TotalContributions"].Value = employer.TotalContributions;
				row.Cells["TotalEmployees"].Value = employer.TotalEmployees;
				row.Cells["EmployerEmailAddress"].Value = employer.EmployerEmailAddress;
			}
		}
	}
}
