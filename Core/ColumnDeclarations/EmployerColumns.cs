namespace Core.ColumnDeclarations
{
	public static class EmployerColumns
	{
		public static readonly PayrollColumn[] Columns =
		[
			new PayrollColumn("8002", "RecordType", 4, defaultValue: "UIEM"),
			new PayrollColumn("8115", "EmployerUIFReferenceNo", 9, zeroFillFromLeft: true),
			new PayrollColumn("8120", "PAYENumber", 10, ColumnType.Numeric),
			new PayrollColumn("8130", "TotalGrossTaxableRemuneration", 16, ColumnType.Amount),
			new PayrollColumn("8135", "TotalGrossRemunerationSubjectToUIF", 16, ColumnType.Amount),
			new PayrollColumn("8140", "TotalContributions", 16, ColumnType.Amount),
			new PayrollColumn("8150", "TotalEmployees", 15, ColumnType.Numeric),
			new PayrollColumn("8160", "EmployerEmailAddress", 50)
		];
	}
}
