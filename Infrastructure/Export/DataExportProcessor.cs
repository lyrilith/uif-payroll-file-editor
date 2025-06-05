using Core.Models;
using Core.ColumnDeclarations;
using System.Reflection;

namespace Infrastructure.Export
{
	public class DataExportProcessor
	{
		public static string[] Process(
			IEnumerable<Creator> creators,
			IEnumerable<Employee> employees,
			IEnumerable<Employer> employers)
		{
			return GetCreatorRows(creators)
				.Concat(GetEmployeeEmployerRows(employees, employers))
				.ToArray();
		}

		private static IEnumerable<string> GetCreatorRows(IEnumerable<Creator> creators)
		{
			foreach (var creator in creators)
			{
				yield return FormatRow(creator, CreatorColumns.Columns);
			}
		}

		private static IEnumerable<string> GetEmployeeEmployerRows(IEnumerable<Employee> employees, IEnumerable<Employer> employers)
		{
			int currentEmployerID = 1;

			var sortedEmployees = employees.OrderBy(e => e.EmployerID).ToList();
			foreach (var employee in sortedEmployees)
			{
				if (employee.EmployerID != currentEmployerID)
				{
					var currentEmployer = employers.FirstOrDefault(e => e.EmployerID == currentEmployerID);
					currentEmployerID++;
					if (currentEmployer != null)
						yield return FormatRow(currentEmployer, EmployerColumns.Columns);
				}

				yield return FormatRow(employee, EmployeeColumns.Columns);
			}

			var lastEmployer = employers.FirstOrDefault(e => e.EmployerID == currentEmployerID);
			if (lastEmployer != null)
				yield return FormatRow(lastEmployer, EmployerColumns.Columns);
		}

		private static string FormatRow<T>(T model, PayrollColumn[] columns)
		{
			var parts = new List<string>();
			var type = typeof(T);

			foreach (var col in columns)
			{
				var prop = type.GetProperty(col.Name, BindingFlags.Public | BindingFlags.Instance);
				if (prop == null) continue;
				var value = prop.GetValue(model);

				string formatted = FormatValue(col, value);
				if (!string.IsNullOrEmpty(formatted))
				{
					parts.Add(col.Code);
					parts.Add(formatted);
				}
			}

			return string.Join(",", parts);
		}

		private static string FormatValue(PayrollColumn col, object value)
		{
			if (value == null) return "";

			switch (col.ColumnType)
			{
				case ColumnType.Amount:
					if (value is decimal d && d != 0)
						return d.ToString("#.##");
					return "";
				case ColumnType.Date:
					if (DateTime.TryParse(value.ToString(), out var dt))
						return dt.ToString("yyyyMMdd");
					return "";
				case ColumnType.ShortDate:
					if (DateTime.TryParse(value.ToString(), out var sdt))
						return sdt.ToString("yyyyMM");
					return "";
				case ColumnType.Numeric:
					return value.ToString();
				default:
					// Handle zero fill for string values
					if (value is string s)
					{
						if (col.ZeroFillFromLeft && col.MaxDigits > 0)
							s = s.PadLeft(col.MaxDigits, '0');
						return Quote(s);
					}
					return Quote(value.ToString());
			}
		}

		private static string Quote(string value)
			=> string.IsNullOrEmpty(value) ? "" : $"\"{value}\"";
	}
}
