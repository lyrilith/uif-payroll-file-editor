namespace UIFRecordApp.ColumnDeclarations
{
	public class PayrollColumn
	{
		public PayrollColumn(string code, string name, int maxDigits, ColumnType columnType = ColumnType.Alphanumeric, string defaultValue = "", bool zeroFillFromLeft = false, Dictionary<string, string> comboBoxDataSource = null)
		{
			Code = code;
			Name = name;
			MaxDigits = maxDigits;
			ColumnType = columnType;
			DefaultValue = defaultValue;
			ZeroFillFromLeft = zeroFillFromLeft;
			ComboBoxDataSource = comboBoxDataSource;
		}

		public string Name { get; }
		public string Code { get; }
		public ColumnType ColumnType { get; }
		public int MaxDigits { get; }
		public string DefaultValue { get; }
		public bool ZeroFillFromLeft { get; }
		public Dictionary<string, string> ComboBoxDataSource { get; }
	}
}
