using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using UIFPayrollFileEditor.Export;
using UIFPayrollFileEditor.Import;

namespace UIFRecordApp
{
	public partial class UIFPayrollFileEditor : Form
	{
		private DateTimePicker datePicker;
		private DateTimePicker monthPicker;
		private readonly string[] dateColumns1 = ["PayrollMonth"];
		private readonly string[] dateColumns2 = ["DateOfBirth", "DateEmployedFrom", "DateEmployedTo"];

		private readonly BindingSource employmentStatusBindingSource = new();
		private readonly BindingSource nonContributionReasonBindingSource = new();
		private readonly BindingSource bankAccountTypeBindingSource = new();

		private readonly string creatorGridPersistPath =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UIFRecordApp", "creatorDataGrid.json");

		// Field to track the row index where the context menu was invoked
		private int _contextMenuRowIndex = -1;

		public UIFPayrollFileEditor()
		{
			InitializeComponent();
			this.datePicker = CreateDatePicker();
			this.monthPicker = CreateMonthPicker();

			employmentStatusBindingSource.DataSource = Core.DataSources.EmploymentStatusDataSource.ToList();
			var employmentStatusCol = employeeDataGrid.Columns["EmploymentStatus"] as DataGridViewComboBoxColumn;
			if (employmentStatusCol != null)
			{
				employmentStatusCol.DataSource = employmentStatusBindingSource;
				employmentStatusCol.DisplayMember = "Value"; // Show display name
				employmentStatusCol.ValueMember = "Key";     // Store code
				employmentStatusCol.ValueType = typeof(string);
			}

			nonContributionReasonBindingSource.DataSource = Core.DataSources.NonContributionReasonDataSource.ToList();
			var nonContributionReasonCol = employeeDataGrid.Columns["ReasonForNonContribution"] as DataGridViewComboBoxColumn;
			if (nonContributionReasonCol != null)
			{
				nonContributionReasonCol.DataSource = nonContributionReasonBindingSource;
				nonContributionReasonCol.DisplayMember = "Value"; // Show display name
				nonContributionReasonCol.ValueMember = "Key";     // Store code
				nonContributionReasonCol.ValueType = typeof(string);
			}

			bankAccountTypeBindingSource.DataSource = Core.DataSources.BankAccountTypeDataSource.ToList();
			var bankAccountTypeCol = employeeDataGrid.Columns["BankAccountType"] as DataGridViewComboBoxColumn;
			if (bankAccountTypeCol != null)
			{
				bankAccountTypeCol.DataSource = bankAccountTypeBindingSource;
				bankAccountTypeCol.DisplayMember = "Value"; // Show display name
				bankAccountTypeCol.ValueMember = "Key";     // Store code
				bankAccountTypeCol.ValueType = typeof(string);
			}

			// Subscribe to RowsAdded event for employerDataGrid
			this.employerDataGrid.RowsAdded += EmployerDataGrid_RowsAdded;
			this.employeeDataGrid.DefaultValuesNeeded += EmployeeDataGrid_DefaultValuesNeeded;

			// Set EmployerID for the first row if it exists (and is not the new row placeholder)
			if (employerDataGrid.Rows.Count > 0)
			{
				int colIdx = -1;
				foreach (DataGridViewColumn col in employerDataGrid.Columns)
				{
					if (col.Name == "EmployerID")
					{
						colIdx = col.Index;
						break;
					}
				}
				if (colIdx != -1)
				{
					employerDataGrid.Rows[0].Cells[colIdx].Value = 1;
				}
			}

			employeeDataGrid.CellValidating += DataGridView_CellValidating;
			employeeDataGrid.RowValidating += EmployeeDataGrid_RowValidating;
			employeeDataGrid.CellEndEdit += EmployeeDataGrid_CellEndEdit;

			// Register EditingControlShowing for numeric-only columns
			creatorDataGrid.EditingControlShowing += EmployeeDataGridView_EditingControlShowing;
			employeeDataGrid.EditingControlShowing += EmployeeDataGridView_EditingControlShowing;
			employerDataGrid.EditingControlShowing += EmployeeDataGridView_EditingControlShowing;

			//creatorDataGrid.CellClick += CreatorDataGrid_CellClick;
			creatorDataGrid.CellEnter += CreatorDataGrid_CellClick;
			employeeDataGrid.CellEnter += EmployeeDataGrid_CellClick;

			// Load persisted creatorDataGrid records if available
			LoadCreatorDataGrid();

			// Add context menu for row deletion to all grids
			AddDeleteRowContextMenu(employeeDataGrid);
			AddDeleteRowContextMenu(employerDataGrid);

			// Register MouseDown to track right-clicked row for each grid
			employeeDataGrid.MouseDown += DataGridView_MouseDown_SetContextRow;
			employerDataGrid.MouseDown += DataGridView_MouseDown_SetContextRow;
		}

		private DateTimePicker CreateDatePicker()
		{
			var datePicker = new DateTimePicker
			{
				Format = DateTimePickerFormat.Custom,
				CustomFormat = "yyyy-MM-dd"
			};
			employeeDataGrid.Controls.Add(datePicker);
			SetupDatePickerEvents(employeeDataGrid, datePicker, "yyyy-MM-dd");
			return datePicker;
		}

		private DateTimePicker CreateMonthPicker()
		{
			var monthPicker = new DateTimePicker
			{
				Format = DateTimePickerFormat.Custom,
				CustomFormat = "yyyy-MM",        // Display only year and month
				ShowUpDown = true,               // Use up/down buttons instead of calendar dropdown
				Width = 100                      // Optional: adjust width
			};
			creatorDataGrid.Controls.Add(monthPicker);
			SetupDatePickerEvents(creatorDataGrid, monthPicker, "yyyy-MM");
			return monthPicker;
		}

		private void SetupDatePickerEvents(DataGridView dataGrid, DateTimePicker datePicker, string format)
		{
			datePicker.Visible = false;

			datePicker.CloseUp += (s, e) =>
			{
				var cell = dataGrid.CurrentCell;
				if (cell != null)
				{
					cell.Value = datePicker.Value.ToString(format);
				}
				datePicker.Visible = false;
			};

			datePicker.LostFocus += (s, e) =>
			{
				var cell = dataGrid.CurrentCell;
				if (cell != null)
				{
					cell.Value = datePicker.Value.ToString(format);
				}
				datePicker.Visible = false; // Hide the date picker when it loses focus
			};

			datePicker.ValueChanged += (s, e) =>
			{
				var cell = dataGrid.CurrentCell;
				if (cell != null)
				{
					cell.Value = datePicker.Value.ToString(format);
				}
			};
		}

		private void CreatorDataGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (dateColumns1.Contains(creatorDataGrid.Columns[e.ColumnIndex].Name))
			{
				Rectangle rect = creatorDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
				monthPicker.Size = rect.Size;
				monthPicker.Location = rect.Location;
				monthPicker.Visible = true;

				var val = creatorDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
				if (DateTime.TryParse(val?.ToString(), out var dt))
					monthPicker.Value = dt;
				else
					monthPicker.Value = DateTime.Today;

				monthPicker.Focus();
			}
		}

		private void EmployeeDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dateColumns2.Contains(employeeDataGrid.Columns[e.ColumnIndex].Name))
			{
				Rectangle rect = employeeDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
				datePicker.Size = rect.Size;
				datePicker.Location = rect.Location;
				datePicker.Visible = true;

				var val = employeeDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
				if (DateTime.TryParse(val?.ToString(), out var dt))
					datePicker.Value = dt;
				else
					datePicker.Value = DateTime.Today;

				datePicker.Focus();
			}
		}

		private void exportMenuButton_Click(object sender, EventArgs e)
		{
			if (creatorDataGrid.Rows.Count <= 1 && employeeDataGrid.Rows.Count <= 1 && employerDataGrid.Rows.Count <= 1)
			{
				MessageBox.Show("No data to export.", "CSV Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (employeeDataGrid.Rows.Cast<DataGridViewRow>().Any(row => !string.IsNullOrEmpty(row.ErrorText) || row.Cells.Cast<DataGridViewCell>().Any(cell => !string.IsNullOrEmpty(cell.ErrorText))))
			{
				var result = MessageBox.Show("There are validation errors in the Employee grid that need to be fixed. \n\nAn invalid file will be rejected by SARS. \n\nWould you like to export anyway?", "CSV Export", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.No)
				{
					return;
				}
			}

			ExportGridsToCsv();
		}

		private void ExportGridsToCsv()
		{
			string uifNo = DataExportProcessor.RetrieveCreatorUIFNumber(creatorDataGrid);
			using (var sfd = new SaveFileDialog
			{
				Filter = "CSV files (*.csv)|*.csv",
				Title = "Export to CSV",
				FileName = string.IsNullOrEmpty(uifNo) || uifNo.Length < 8 ? "CreatorUIFNo.FileNumber.csv" : string.Join("", uifNo.TakeLast(8)) + ".001.csv"
			})
			{
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (var sw = new StreamWriter(sfd.FileName))
					{
						var result = DataExportProcessor.Process(creatorDataGrid, employeeDataGrid, employerDataGrid);
						foreach (var line in result)
						{
							sw.WriteLine(line);
						}
					}

					MessageBox.Show("Export successful!", "CSV Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void EmployerDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			// Find the EmployerNumber column index
			int colIdx = -1;
			foreach (DataGridViewColumn col in employerDataGrid.Columns)
			{
				if (col.Name == "EmployerID")
				{
					colIdx = col.Index;
					break;
				}
			}
			if (colIdx == -1) return;

			// Assign EmployerNumber only to newly added rows
			for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
			{
				var row = employerDataGrid.Rows[i];
				if (row.IsNewRow)
				{
					if (row.Cells[colIdx].Value == null || string.IsNullOrEmpty(row.Cells[colIdx].Value.ToString()))
					{
						row.Cells[colIdx].Value = row.Index + 1;
					}
				}
			}
		}

		private void EmployeeDataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			var dgv = (DataGridView)sender;
			int prevRowIndex = e.Row.Index - 1;

			if (prevRowIndex >= 0 && prevRowIndex < dgv.Rows.Count)
			{
				var prevValue = dgv.Rows[prevRowIndex].Cells["EmployeeEmployerID"].Value;
				e.Row.Cells["EmployeeEmployerID"].Value = prevValue;
			}
			else
				e.Row.Cells["EmployeeEmployerID"].Value = 1;

			e.Row.Cells["EmploymentStatus"].Value = "01";
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var confirmResult = MessageBox.Show("Are you sure you want to create a new payroll file? This will clear all current data.",
				"New Payroll",
				MessageBoxButtons.YesNo);

			if (confirmResult == DialogResult.Yes)
			{
				ClearGrids();
			}
		}

		private void ClearGrids()
		{
			creatorDataGrid.Rows.Clear();
			employeeDataGrid.Rows.Clear();
			employerDataGrid.Rows.Clear();
			EnsureCreatorDataGridHasOneRow();
		}

		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (creatorDataGrid.Rows.Count > 1 || employeeDataGrid.Rows.Count > 1 || employerDataGrid.Rows.Count > 1)
			{
				var confirmResult = MessageBox.Show("Are you sure you want to import data? This will clear all current data.",
					"Import Data",
					MessageBoxButtons.YesNo);
				if (confirmResult != DialogResult.Yes)
					return;
			}

			using (var ofd = new OpenFileDialog
			{
				Filter = "CSV files (*.csv)|*.csv",
				Title = "Import from CSV"
			})
			{
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						DataImportProcessor.PopulateGridsFromCsv(
							ofd.FileName,
							creatorDataGrid,
							employeeDataGrid,
							employerDataGrid
						);
						EnsureCreatorDataGridHasOneRow();
						MessageBox.Show("Import successful!", "CSV Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Import failed: {ex.Message}", "CSV Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			var dataGridView = sender as DataGridView;
			if (dataGridView == null) return;

			if (dataGridView.Rows[e.RowIndex].IsNewRow) return; // Skip validation for new row placeholder

			var colName = dataGridView.Columns[e.ColumnIndex].Name;

			string GetStringValue(string columnName)
			{
				return dataGridView.Rows[e.RowIndex].Cells[columnName].Value?.ToString() ?? "";

			}

			AddCellValidation(e, dataGridView, (input) => !string.IsNullOrEmpty(input) && input.Length != 13, "ID number must be a valid 13 digit bar coded RSA national ID number.", ["IDNumber"]);
			AddCellValidation(e, dataGridView, (input) =>
			{
				var nonContributionValue = GetStringValue("ReasonForNonContribution");
				var grossTaxableRemuneration = input;
				if (string.IsNullOrEmpty(nonContributionValue))
				{
					if (string.IsNullOrEmpty(grossTaxableRemuneration))
						return true;
					if (decimal.TryParse(grossTaxableRemuneration, out var result) && result <= 0)
						return true;
				}

				return false;
			}, "A reason for non-contribution must be specified if GrossTaxableRemuneration is zero.", ["ReasonForNonContribution", "GrossTaxableRemuneration"]);
			AddCellValidation(e, dataGridView, (input) =>
			{
				var nonContributionValue = GetStringValue("ReasonForNonContribution");
				var grossTaxableRemuneration = input;
				if (string.IsNullOrEmpty(nonContributionValue))
				{
					if (string.IsNullOrEmpty(grossTaxableRemuneration))
						return true;
					if (decimal.TryParse(grossTaxableRemuneration, out var result) && result <= 0)
						return true;
				}

				return false;
			}, "A reason for non-contribution must be specified if RemunerationSubjectToUIF is zero.", ["ReasonForNonContribution", "RemunerationSubjectToUIF"]);
			AddCellValidation(e, dataGridView, (input) =>
			{
				var nonContributionValue = GetStringValue("ReasonForNonContribution");
				var grossTaxableRemuneration = input;
				if (string.IsNullOrEmpty(nonContributionValue))
				{
					if (string.IsNullOrEmpty(grossTaxableRemuneration))
						return true;
					if (decimal.TryParse(grossTaxableRemuneration, out var result) && result <= 0)
						return true;
				}

				return false;
			}, "A reason for non-contribution must be specified if UIFContribution is zero.", ["ReasonForNonContribution", "UIFContribution"]);
		}

		private void EmployeeDataGrid_RowValidating(object? sender, DataGridViewCellCancelEventArgs e)
		{
			var dataGridView = sender as DataGridView;
			if (dataGridView == null) return;

			if (dataGridView.Rows[e.RowIndex].IsNewRow) return; // Skip validation for new row placeholder

			if (dataGridView.IsCurrentRowDirty)
				dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

			string GetStringValue(string columnName)
			{
				return dataGridView.Rows[e.RowIndex].Cells[columnName].Value?.ToString() ?? "";
			}

			AddRowValidation(e, dataGridView, () => string.IsNullOrEmpty(GetStringValue("IDNumber")) && string.IsNullOrEmpty(GetStringValue("OtherNumber")) && string.IsNullOrEmpty(GetStringValue("AlternateNumber")), "Either IDNumber, OtherNumber, or AlternateNumber must be specified.", ["IDNumber", "OtherNumber", "AlternateNumber"]);
			AddRowValidation(e, dataGridView, () => !string.IsNullOrEmpty(GetStringValue("IDNumber")) && GetStringValue("IDNumber").Length != 13, "ID number must be a valid 13 digit bar coded RSA national ID number.", ["IDNumber"]);
			AddRowValidation(e, dataGridView, () =>
			{
				var nonContributionValue = GetStringValue("ReasonForNonContribution");
				var grossTaxableRemuneration = GetStringValue("GrossTaxableRemuneration");
				if (string.IsNullOrEmpty(nonContributionValue))
				{
					if (string.IsNullOrEmpty(grossTaxableRemuneration))
						return true;
					if (decimal.TryParse(grossTaxableRemuneration, out var result) && result <= 0)
						return true;
				}

				return false;
			}, "A reason for non-contribution must be specified if GrossTaxableRemuneration is zero.", ["ReasonForNonContribution", "GrossTaxableRemuneration"]);
			AddRowValidation(e, dataGridView, () =>
			{
				var nonContributionValue = GetStringValue("ReasonForNonContribution");
				var grossTaxableRemuneration = GetStringValue("RemunerationSubjectToUIF");
				if (string.IsNullOrEmpty(nonContributionValue))
				{
					if (string.IsNullOrEmpty(grossTaxableRemuneration))
						return true;
					if (decimal.TryParse(grossTaxableRemuneration, out var result) && result <= 0)
						return true;
				}

				return false;
			}, "A reason for non-contribution must be specified if RemunerationSubjectToUIF is zero.", ["ReasonForNonContribution", "RemunerationSubjectToUIF"]);
			AddRowValidation(e, dataGridView, () =>
			{
				var nonContributionValue = GetStringValue("ReasonForNonContribution");
				var grossTaxableRemuneration = GetStringValue("UIFContribution");
				if (string.IsNullOrEmpty(nonContributionValue))
				{
					if (string.IsNullOrEmpty(grossTaxableRemuneration))
						return true;
					if (decimal.TryParse(grossTaxableRemuneration, out var result) && result <= 0)
						return true;
				}

				return false;
			}, "A reason for non-contribution must be specified if UIFContribution is zero.", ["ReasonForNonContribution", "UIFContribution"]);
		}

		private static void AddCellValidation(DataGridViewCellValidatingEventArgs e, DataGridView dgv, Func<string, bool> validationIsInvalid, string errorMessage, string[] applicableColumns)
		{
			var colName = dgv.Columns[e.ColumnIndex].Name;
			if (applicableColumns.Contains(colName))
			{
				string input = e.FormattedValue?.ToString() ?? "";
				if (validationIsInvalid(input))
				{
					dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = errorMessage;
				}
				else
				{
					dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
				}
			}
		}

		private static void AddRowValidation(DataGridViewCellCancelEventArgs e, DataGridView dgv, Func<bool> validationIsInvalid, string errorMessage, string[] applicableColumns)
		{
			if (validationIsInvalid())
			{
				dgv.Rows[e.RowIndex].ErrorText = errorMessage;
				foreach (var column in applicableColumns)
				{
					var currentErrorText = dgv.Rows[e.RowIndex].Cells[column].ErrorText;
					dgv.Rows[e.RowIndex].Cells[column].ErrorText = errorMessage;
				}
			}
			else
			{
				dgv.Rows[e.RowIndex].ErrorText = "";
				foreach (var column in applicableColumns)
					dgv.Rows[e.RowIndex].Cells[column].ErrorText = "";
			}
		}

		// Handler to enforce numeric-only input in specific columns
		private void EmployeeDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			var dgv = sender as DataGridView;
			if (dgv == null) return;

			// Remove any existing handlers
			if (e.Control is TextBox tb)
			{
				tb.KeyPress -= NumericTextBox_KeyPress;
				tb.TextChanged -= NumericTextBox_TextChanged;
				tb.KeyPress -= AmountTextBox_KeyPress;
				tb.TextChanged -= AmountTextBox_TextChanged;

				int colIndex = dgv.CurrentCell?.ColumnIndex ?? -1;
				if (colIndex >= 0)
				{
					var colName = dgv.Columns[colIndex].Name;
					var numericColumns = new[]
					{
						"CreatorUIFReferenceNo",
						"EmployeeUIFReferenceNo",
						"EmployerUIFReferenceNo",
						"IDNumber",
						"BankBranchCode",
						"BankAccountNumber",
						"PAYENumber",
						"TotalEmployees"
					};
					var amountColumns = new[]
					{
						"GrossTaxableRemuneration",
						"RemunerationSubjectToUIF",
						"UIFContribution",
						"TotalGrossTaxableRemuneration",
						"TotalGrossRemunerationSubjectToUIF",
						"TotalContributions"
					};
					if (numericColumns.Contains(colName))
					{
						tb.KeyPress += NumericTextBox_KeyPress;
						tb.TextChanged += NumericTextBox_TextChanged;
					}
					if (amountColumns.Contains(colName))
					{
						tb.KeyPress += AmountTextBox_KeyPress;
						tb.TextChanged += AmountTextBox_TextChanged;
					}
				}
			}
		}

		// Suppress non-digit key input
		private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			var tb = sender as TextBox;
			if (tb == null) return;

			char decimalSeparator = '.';

			// Allow control keys (backspace, etc.)
			if (char.IsControl(e.KeyChar))
				return;

			// Allow digits
			if (char.IsDigit(e.KeyChar))
				return;

			// Allow one decimal separator, but not as the first character and not if already present
			if (e.KeyChar == decimalSeparator)
			{
				if (tb.Text.IndexOf(decimalSeparator) == -1 && tb.SelectionStart != 0)
					return;
			}

			// Block all other input
			e.Handled = true;
		}

		// Remove non-numeric characters on paste or programmatic changes
		private void NumericTextBox_TextChanged(object sender, EventArgs e)
		{
			var tb = sender as TextBox;
			if (tb == null) return;
			string original = tb.Text;
			string filtered = new string(original.Where(char.IsDigit).ToArray());
			if (original != filtered)
			{
				int selStart = tb.SelectionStart;
				tb.Text = filtered;
				tb.SelectionStart = Math.Min(selStart, filtered.Length);
			}
		}

		private void AmountTextBox_TextChanged(object sender, EventArgs e)
		{
			var tb = sender as TextBox;
			if (tb == null) return;

			char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
			string original = tb.Text;
			int selStart = tb.SelectionStart;

			// Build filtered string: allow digits, at most one decimal separator
			bool seenSeparator = false;
			var filteredChars = new List<char>(original.Length);
			foreach (char c in original)
			{
				if (char.IsDigit(c))
				{
					filteredChars.Add(c);
				}
				else if (c == decimalSeparator && !seenSeparator)
				{
					filteredChars.Add(c);
					seenSeparator = true;
				}
				// Ignore all other characters
			}
			string filtered = new string(filteredChars.ToArray());

			if (original != filtered)
			{
				tb.Text = filtered;
				// Adjust caret position
				tb.SelectionStart = Math.Min(selStart, filtered.Length);
			}
		}

		private void aboutMenuItem_Click(object sender, EventArgs e)
		{
			string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion ?? "Unknown";

			string aboutText =
				"UIF Record App\n" +
				$"Version: {version}\n" +
				"Author: Tania Welsford\n\n" +
				"This application allows you to manage, import, and export UIF payroll records in CSV format.\n" +
				"Features:\n" +
				"- Data entry and validation for Creator, Employer, and Employee records\n" +
				"- Import/export to CSV\n" +
				"- Numeric-only enforcement for UIF Reference Numbers\n" +
				"- Combo box support for status and account types\n\n" +
				"© 2025 Tania Welsford. All rights reserved.";

			MessageBox.Show(aboutText, "About UIF Record App", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void PayrollConverterApp_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Persist creatorDataGrid
			SaveCreatorDataGrid();

			// Save confirmation logic
			if (creatorDataGrid.Rows.Count > 1 || employeeDataGrid.Rows.Count > 1 || employerDataGrid.Rows.Count > 1)
			{
				var result = MessageBox.Show(
				"Would you like to save your data before exiting?",
				"Save Before Exit",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Question);

				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
					return;
				}
				else if (result == DialogResult.Yes)
				{
					ExportGridsToCsv();
				}
			}

			this.employerDataGrid.RowsAdded -= EmployerDataGrid_RowsAdded;
			this.employeeDataGrid.DefaultValuesNeeded -= EmployeeDataGrid_DefaultValuesNeeded;

			employeeDataGrid.CellValidating -= DataGridView_CellValidating;
			employeeDataGrid.RowValidating -= EmployeeDataGrid_RowValidating;
			employeeDataGrid.CellEndEdit -= EmployeeDataGrid_CellEndEdit;

			// Register EditingControlShowing for numeric-only columns
			creatorDataGrid.EditingControlShowing -= EmployeeDataGridView_EditingControlShowing;
			employeeDataGrid.EditingControlShowing -= EmployeeDataGridView_EditingControlShowing;
			employerDataGrid.EditingControlShowing -= EmployeeDataGridView_EditingControlShowing;

			creatorDataGrid.CellEnter -= CreatorDataGrid_CellClick;
			employeeDataGrid.CellEnter -= EmployeeDataGrid_CellClick;

			// Add context menu for row deletion to all grids
			AddDeleteRowContextMenu(employeeDataGrid);
			AddDeleteRowContextMenu(employerDataGrid);

			// Register MouseDown to track right-clicked row for each grid
			employeeDataGrid.MouseDown -= DataGridView_MouseDown_SetContextRow;
			employerDataGrid.MouseDown -= DataGridView_MouseDown_SetContextRow;
		}

		private void LoadCreatorDataGrid()
		{
			try
			{
				if (File.Exists(creatorGridPersistPath))
				{
					var json = File.ReadAllText(creatorGridPersistPath);
					var rows = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
					if (rows != null)
					{
						creatorDataGrid.Rows.Clear();
						foreach (var rowDict in rows)
						{
							int idx = creatorDataGrid.Rows.Add();
							var row = creatorDataGrid.Rows[idx];
							foreach (DataGridViewColumn col in creatorDataGrid.Columns)
							{
								if (rowDict.TryGetValue(col.Name, out var val))
									row.Cells[col.Name].Value = val;
							}
						}
					}
				}
			}
			catch
			{
				// Ignore errors, do not load if file is corrupt
			}
			finally
			{
				EnsureCreatorDataGridHasOneRow();
			}
		}

		private void SaveCreatorDataGrid()
		{
			try
			{
				var rows = new List<Dictionary<string, string>>();
				foreach (DataGridViewRow row in creatorDataGrid.Rows)
				{
					if (row.IsNewRow) continue;
					var dict = new Dictionary<string, string>();
					foreach (DataGridViewColumn col in creatorDataGrid.Columns)
					{
						var val = row.Cells[col.Name].Value?.ToString() ?? "";
						dict[col.Name] = val;
					}
					rows.Add(dict);
				}
				var dir = Path.GetDirectoryName(creatorGridPersistPath);
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
				var json = JsonSerializer.Serialize(rows, new JsonSerializerOptions { WriteIndented = true });
				File.WriteAllText(creatorGridPersistPath, json);
			}
			catch
			{
				// Ignore errors on save
			}
		}

		// Track the row index where the context menu was invoked
		private void DataGridView_MouseDown_SetContextRow(object sender, MouseEventArgs e)
		{
			var dgv = sender as DataGridView;
			if (dgv == null) return;

			if (e.Button == MouseButtons.Right)
			{
				var hit = dgv.HitTest(e.X, e.Y);
				if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
				{
					_contextMenuRowIndex = hit.RowIndex;
					// Optionally, select the row visually
					dgv.ClearSelection();
					dgv.Rows[hit.RowIndex].Selected = true;
				}
				else
				{
					_contextMenuRowIndex = -1;
				}
			}
		}

		// Add a right-click context menu for deleting rows
		private void AddDeleteRowContextMenu(DataGridView dgv)
		{
			var menu = new ContextMenuStrip();
			var deleteItem = new ToolStripMenuItem("Delete Row");
			deleteItem.Click += (s, e) =>
			{
				// If a context menu row index is set, delete that row
				if (_contextMenuRowIndex >= 0 && _contextMenuRowIndex < dgv.Rows.Count)
				{
					var row = dgv.Rows[_contextMenuRowIndex];
					if (!row.IsNewRow)
						dgv.Rows.RemoveAt(_contextMenuRowIndex);
					_contextMenuRowIndex = -1;
					return;
				}

				// Otherwise, fallback to deleting selected rows
				foreach (DataGridViewRow row in dgv.SelectedRows)
				{
					if (!row.IsNewRow)
						dgv.Rows.Remove(row);
				}
			};
			menu.Items.Add(deleteItem);
			dgv.ContextMenuStrip = menu;
		}

		private void EmployeeDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var dataGridView = sender as DataGridView;
			if (dataGridView == null) return;

			var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			// Force visual update of error text
			dataGridView.InvalidateCell(cell);
		}

		private void EnsureCreatorDataGridHasOneRow()
		{
			if (creatorDataGrid.Rows.Count < 1)
			{
				creatorDataGrid.Rows.Add();
			}
		}
	}
}
