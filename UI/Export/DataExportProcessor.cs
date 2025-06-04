using UIFRecordApp.ColumnDeclarations;

namespace UIFPayrollFileEditor.Export
{
	public class DataExportProcessor
	{
		public static string RetrieveCreatorUIFNumber(DataGridView creatorDataGrid)
		{
			if (creatorDataGrid.Rows.Count > 0 && creatorDataGrid.Columns.Contains("CreatorUIFReferenceNo"))
			{
				var uifNumberCell = creatorDataGrid.Rows[0].Cells["CreatorUIFReferenceNo"];
				if (uifNumberCell.Value != null)
				{
					return uifNumberCell.Value.ToString();
				}
			}
			return string.Empty;
		}

		public static string[] Process(DataGridView creatorDataGrid, DataGridView employeeDataGrid, DataGridView employerDataGrid)
		{
			return GetCreatorRows(creatorDataGrid)
				.Concat(GetEmployeeEmployerRows(employeeDataGrid, employerDataGrid))
				.ToArray();
		}

		private static IEnumerable<string> GetCreatorRows(DataGridView creatorDataGrid)
		{
			return GetRows(creatorDataGrid, CreatorColumns.Columns, "")
				.Select(row => row.Row).ToArray();
		}

		private static IEnumerable<string> GetEmployeeEmployerRows(DataGridView employeeDataGrid, DataGridView employerDataGrid)
		{
			List<string> result = [];
			var employeeRows = GetRows(employeeDataGrid, EmployeeColumns.Columns, "EmployeeEmployerID");
			var employerRows = GetRows(employerDataGrid, EmployerColumns.Columns, "EmployerID");

			int previousEmployerID = 1;
			foreach (var employeeRow in employeeRows)
			{
				if (previousEmployerID == employeeRow.SortColumn)
					result.Add(employeeRow.Row);
				else
				{
					// Add employer row for the previous EmployerID
					var employerRow = employerRows.FirstOrDefault(e => e.SortColumn == previousEmployerID);
					if (employerRow != null)
					{
						result.Add(employerRow.Row);
					}
					// Add employee row for the new EmployerID
					result.Add(employeeRow.Row);
					previousEmployerID = employeeRow.SortColumn;
				}
			}

			var lastEmployerRow = employerRows.FirstOrDefault(e => e.SortColumn == previousEmployerID);
			if (lastEmployerRow != null)
			{
				result.Add(lastEmployerRow.Row);
			}

			return result;
		}

		private static ProcessedRow[] GetRows(DataGridView dataGrid, PayrollColumn[] definedColumns, string sortColumnName)
		{
			List<ProcessedRow> rows = [];
			foreach (DataGridViewRow row in dataGrid.Rows)
			{
				if (!row.IsNewRow)
				{
					var lineParts = new List<string>();
					foreach (var definedColumn in definedColumns)
					{
						if (!string.IsNullOrEmpty(definedColumn.DefaultValue))
						{
							lineParts.Add(definedColumn.Code);
							lineParts.Add(FormatValue(definedColumn, definedColumn.DefaultValue));
						}
						else
						{
							int columnIndex = -1;
							foreach (DataGridViewColumn gridColumn in dataGrid.Columns)
							{
								if (gridColumn.Name == definedColumn.Name)
								{
									columnIndex = gridColumn.Index;
									break;
								}
							}
							if (columnIndex != -1)
							{
								var cellValue = row.Cells[columnIndex].Value?.ToString() ?? "";
								if (!string.IsNullOrWhiteSpace(cellValue))
								{
									lineParts.Add(definedColumn.Code);
									lineParts.Add(FormatValue(definedColumn, cellValue));
								}
							}
							else
							{
								MessageBox.Show($"Column '{definedColumn.Name}' not found in the grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
					rows.Add(new ProcessedRow()
					{
						SortColumn = string.IsNullOrEmpty(sortColumnName) ? 0 : int.TryParse(row.Cells[sortColumnName].Value?.ToString() ?? "0", out int id) ? id : 0,
						Row = string.Join(",", lineParts)
					});
				}
			}

			if (!string.IsNullOrEmpty(sortColumnName))
				rows.Sort((a, b) => a.SortColumn.CompareTo(b.SortColumn));

			return rows.ToArray();
		}

		private static string FormatValue(PayrollColumn column, object value)
		{
			if (value == null)
			{
				return string.Empty;
			}

			switch (column.ColumnType)
			{
				case ColumnType.Numeric:
					return value.ToString();
				case ColumnType.Amount:
					return decimal.TryParse(value.ToString(), out var amount) ? amount.ToString("#.##") : "";
				case ColumnType.Date:
					if (DateTime.TryParse(value.ToString(), out var date))
					{
						return date.ToString("yyyyMMdd");
					}
					return "";
				case ColumnType.ShortDate:
					if (DateTime.TryParse(value.ToString(), out var shortDate))
					{
						return shortDate.ToString("yyyyMM");
					}
					return "";
				default: // Alphanumeric
					{
						value = column.ZeroFillFromLeft ? value.ToString().PadLeft(column.MaxDigits, '0') : value;
						return $@"""{value}""";
					}
			}
		}
	}

	class ProcessedRow
	{
		public int SortColumn { get; set; }
		public string Row { get; set; }
	}
}
