using UIFRecordApp.ColumnDeclarations;

namespace UIFPayrollFileEditor.Import
{
    public static class DataImportProcessor
    {
        public static void PopulateGridsFromCsv(
            string csvFilePath,
            DataGridView creatorDataGrid,
            DataGridView employeeDataGrid,
            DataGridView employerDataGrid)
        {
            var lines = File.ReadAllLines(csvFilePath)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToArray();

            // Clear existing data
            creatorDataGrid.Rows.Clear();
            employeeDataGrid.Rows.Clear();
            employerDataGrid.Rows.Clear();

            // Parse rows into buckets
            var creatorRows = new List<Dictionary<string, string>>();
            var employeeRows = new List<Dictionary<string, string>>();
            var employerRows = new List<Dictionary<string, string>>();


            foreach (var line in lines)
            {
                int employerCount = 1;
                var dict = ParseCsvLineToDict(line, employerCount);
                // Heuristic: decide which grid this row belongs to
                if (dict.Keys.Intersect(CreatorColumns.Columns.Select(c => c.Code)).Count() > 0)
                    creatorRows.Add(dict);
                else if (dict.Keys.Intersect(EmployeeColumns.Columns.Select(c => c.Code)).Count() > 0)
                    employeeRows.Add(dict);
                else if (dict.Keys.Intersect(EmployerColumns.Columns.Select(c => c.Code)).Count() > 0)
                {
					employerRows.Add(dict);
                    employerCount++;
				}
            }

            // Populate creatorDataGrid
            foreach (var rowDict in creatorRows)
            {
                int idx = creatorDataGrid.Rows.Add();
                var row = creatorDataGrid.Rows[idx];
                foreach (var col in CreatorColumns.Columns)
                {
                    if (creatorDataGrid.Columns.Contains(col.Name) && rowDict.TryGetValue(col.Code, out var val))
                        row.Cells[col.Name].Value = UnformatValue(col, val);
                }
            }

            // Populate employeeDataGrid
            foreach (var rowDict in employeeRows)
            {
                int idx = employeeDataGrid.Rows.Add();
                var row = employeeDataGrid.Rows[idx];
                foreach (var col in EmployeeColumns.Columns)
                {
					row.Cells["EmployeeEmployerID"].Value = rowDict.TryGetValue("00", out var employerIDValue) ? employerIDValue : 1;
					if (employeeDataGrid.Columns.Contains(col.Name) && rowDict.TryGetValue(col.Code, out var val))
                        row.Cells[col.Name].Value = UnformatValue(col, val);
                }
            }

            // Populate employerDataGrid
            foreach (var rowDict in employerRows)
            {
                int idx = employerDataGrid.Rows.Add();
                var row = employerDataGrid.Rows[idx];
                foreach (var col in EmployerColumns.Columns)
                {
                    row.Cells["EmployerID"].Value = rowDict.TryGetValue("00", out var employerIDValue) ? employerIDValue : 1;
                    if (employerDataGrid.Columns.Contains(col.Name) && rowDict.TryGetValue(col.Code, out var val))
                        row.Cells[col.Name].Value = UnformatValue(col, val);
                }
            }
        }

        // Helper: parse a line like "A1","202406","B2","John" into a dictionary {A1:202406, B2:John}
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

        // Simple CSV splitter (handles quoted values)
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

        // Unformat value based on column type (reverse of DataProcessor.FormatValue)
        private static object UnformatValue(PayrollColumn column, string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            if (column.ComboBoxDataSource != null)
            {
                if (column.ComboBoxDataSource.ContainsKey(value))
                    return value;
                else if (column.ComboBoxDataSource.ContainsKey("0" + value))
                    return "0" + value;
                else if (column.ComboBoxDataSource.ContainsKey(value.Replace("0", "")))
					return value.Replace("0", "");
				else
					return column.ComboBoxDataSource.First().Key;
			}
            else
                switch (column.ColumnType)
                {
                    case ColumnType.Numeric:
                        if (int.TryParse(value, out var n)) return n;
                        return value;
                    case ColumnType.Amount:
                        if (decimal.TryParse(value, out var d)) return d;
                        return value;
                    case ColumnType.Date:
                        if (DateTime.TryParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var dt))
                            return dt;
                        return value;
                    case ColumnType.ShortDate:
                        if (DateTime.TryParseExact(value, "yyyyMM", null, System.Globalization.DateTimeStyles.None, out var sdt))
                            return sdt;
                        return value;
                    default:
                        return value.Trim('"');
                }
        }
    }
}
