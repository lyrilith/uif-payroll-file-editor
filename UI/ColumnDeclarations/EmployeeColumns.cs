namespace UIFRecordApp.ColumnDeclarations
{
	public static class EmployeeColumns
	{
		public static readonly PayrollColumn[] Columns =
		[
			new PayrollColumn("8001", "RecordType", 4, defaultValue: "UIWK"),
			new PayrollColumn("8110", "EmployeeUIFReferenceNo", 9, zeroFillFromLeft: true),
			new PayrollColumn("8200", "IDNumber", 13, ColumnType.Numeric),
			new PayrollColumn("8210", "OtherNumber", 16),
			new PayrollColumn("8220", "AlternateNumber", 25),
			new PayrollColumn("8230", "Surname", 120),
			new PayrollColumn("8240", "FirstNames", 90),
			new PayrollColumn("8250", "DateOfBirth", 8, ColumnType.Date),
			new PayrollColumn("8260", "DateEmployedFrom", 8, ColumnType.Date),
			new PayrollColumn("8270", "DateEmployedTo", 8, ColumnType.Date),
			new PayrollColumn("8280", "EmploymentStatus", 2, ColumnType.Numeric, comboBoxDataSource: Core.DataSources.EmploymentStatusDataSource),
			new PayrollColumn("8290", "ReasonForNonContribution", 2, ColumnType.Numeric, comboBoxDataSource: Core.DataSources.NonContributionReasonDataSource),
			new PayrollColumn("8300", "GrossTaxableRemuneration", 16, ColumnType.Amount),
			new PayrollColumn("8310", "RemunerationSubjectToUIF", 16, ColumnType.Amount),
			new PayrollColumn("8320", "UIFContribution", 16, ColumnType.Amount),
			new PayrollColumn("8330", "BankBranchCode", 8, ColumnType.Numeric),
			new PayrollColumn("8340", "BankAccountNo", 16, ColumnType.Numeric),
			new PayrollColumn("8350", "BankAccountType", 2, ColumnType.Numeric, comboBoxDataSource: Core.DataSources.BankAccountTypeDataSource)
		];
	}
}