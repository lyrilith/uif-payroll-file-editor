namespace UIFRecordApp.ColumnDeclarations
{
	public static class CreatorColumns
	{
		public static readonly PayrollColumn[] Columns =
		[
			new PayrollColumn("8000", "RecordType", 4, defaultValue: "UICR"),
			new PayrollColumn("8010", "FormatType", 2, defaultValue: "U1"),
			new PayrollColumn("8015", "VersionNo", 2, defaultValue: "E03"),
			new PayrollColumn("8020", "CreatorUIFReferenceNo", 9, zeroFillFromLeft: true),
			new PayrollColumn("8030", "TestLiveIndicator", 4, defaultValue: "LIVE"),
			new PayrollColumn("8040", "ContactPerson", 30),
			new PayrollColumn("8050", "ContactTelephoneNo", 16),
			new PayrollColumn("8060", "ContactEmailAddress", 50),
			new PayrollColumn("8070", "PayrollMonth", 6, ColumnType.ShortDate)
		];
	}
}
