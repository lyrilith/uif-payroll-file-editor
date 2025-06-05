using System.Collections.Generic;
using System.Windows.Forms;
using Core.Models;

namespace UIFRecordApp
{
    /// <summary>
    /// Provides methods to populate DataGridViews from model lists.
    /// </summary>
    public static class ModelToDataGridViewMapping
    {
        /// <summary>
        /// Populates the creatorDataGrid with the given list of Creator models.
        /// </summary>
        public static void PopulateCreatorGrid(DataGridView creatorDataGrid, IEnumerable<Creator> creators)
        {
            creatorDataGrid.Rows.Clear();
            foreach (var creator in creators)
            {
                int idx = creatorDataGrid.Rows.Add();
                var row = creatorDataGrid.Rows[idx];
                row.Cells["CreatorUIFReferenceNo"].Value = creator.CreatorUIFReferenceNo;
                row.Cells["ContactPerson"].Value = creator.ContactPerson;
                row.Cells["ContactTelephoneNo"].Value = creator.ContactTelephoneNo;
                row.Cells["ContactEmailAddress"].Value = creator.ContactEmailAddress;
                row.Cells["PayrollMonth"].Value = creator.PayrollMonth;
            }
        }

        /// <summary>
        /// Populates the employeeDataGrid with the given list of Employee models.
        /// </summary>
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
                row.Cells["DateOfBirth"].Value = employee.DateOfBirth;
                row.Cells["DateEmployedFrom"].Value = employee.DateEmployedFrom;
                row.Cells["DateEmployedTo"].Value = employee.DateEmployedTo;
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

        /// <summary>
        /// Populates the employerDataGrid with the given list of Employer models.
        /// </summary>
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
