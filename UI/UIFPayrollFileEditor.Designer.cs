namespace UI
{
	partial class UIFPayrollFileEditor
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIFPayrollFileEditor));
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			employerDataGrid = new DataGridView();
			EmployerID = new DataGridViewTextBoxColumn();
			EmployerUIFReferenceNo = new DataGridViewTextBoxColumn();
			PAYENumber = new DataGridViewTextBoxColumn();
			TotalGrossTaxableRemuneration = new DataGridViewTextBoxColumn();
			TotalGrossRemunerationSubjectToUIF = new DataGridViewTextBoxColumn();
			TotalContributions = new DataGridViewTextBoxColumn();
			TotalEmployees = new DataGridViewTextBoxColumn();
			EmployerEmailAddress = new DataGridViewTextBoxColumn();
			tabControl = new TabControl();
			creatorTab = new TabPage();
			tableLayoutPanel1 = new TableLayoutPanel();
			payrollMonthDatePicker = new DateTimePicker();
			contactTelephoneNoLabel = new Label();
			uifReferenceNoLabel = new Label();
			contactPersonLabel = new Label();
			contactEmailAddressLabel = new Label();
			payrollMonthLabel = new Label();
			uifReferenceNoTextBox = new TextBox();
			contactPersonTextBox = new TextBox();
			contactTelephoneNoTextBox = new TextBox();
			contactEmailAddressTextBox = new TextBox();
			employeeTab = new TabPage();
			employeeDataGrid = new DataGridView();
			EmployeeEmployerID = new DataGridViewTextBoxColumn();
			EmployeeUIFReferenceNo = new DataGridViewTextBoxColumn();
			IDNumber = new DataGridViewTextBoxColumn();
			OtherNumber = new DataGridViewTextBoxColumn();
			AlternateNumber = new DataGridViewTextBoxColumn();
			Surname = new DataGridViewTextBoxColumn();
			FirstNames = new DataGridViewTextBoxColumn();
			DateOfBirth = new DataGridViewTextBoxColumn();
			DateEmployedFrom = new DataGridViewTextBoxColumn();
			DateEmployedTo = new DataGridViewTextBoxColumn();
			EmploymentStatus = new DataGridViewComboBoxColumn();
			GrossTaxableRemuneration = new DataGridViewTextBoxColumn();
			RemunerationSubjectToUIF = new DataGridViewTextBoxColumn();
			UIFContribution = new DataGridViewTextBoxColumn();
			ReasonForNonContribution = new DataGridViewComboBoxColumn();
			BankBranchCode = new DataGridViewTextBoxColumn();
			BankAccountNo = new DataGridViewTextBoxColumn();
			BankAccountType = new DataGridViewComboBoxColumn();
			employerTab = new TabPage();
			menuStrip1 = new MenuStrip();
			fileMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			newMenuItem = new ToolStripMenuItem();
			openMenuItem = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			saveMenuItem = new ToolStripMenuItem();
			toolStripSeparator3 = new ToolStripSeparator();
			exitMenuItem = new ToolStripMenuItem();
			helpMenuItem = new ToolStripMenuItem();
			aboutMenuItem = new ToolStripMenuItem();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)employerDataGrid).BeginInit();
			tabControl.SuspendLayout();
			creatorTab.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			employeeTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)employeeDataGrid).BeginInit();
			employerTab.SuspendLayout();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// employerDataGrid
			// 
			employerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			employerDataGrid.Columns.AddRange(new DataGridViewColumn[] { EmployerID, EmployerUIFReferenceNo, PAYENumber, TotalGrossTaxableRemuneration, TotalGrossRemunerationSubjectToUIF, TotalContributions, TotalEmployees, EmployerEmailAddress });
			employerDataGrid.Dock = DockStyle.Top;
			employerDataGrid.Location = new Point(3, 3);
			employerDataGrid.Name = "employerDataGrid";
			employerDataGrid.RowHeadersWidth = 51;
			employerDataGrid.Size = new Size(1505, 254);
			employerDataGrid.TabIndex = 2;
			// 
			// EmployerID
			// 
			EmployerID.HeaderText = "EmployerID";
			EmployerID.MinimumWidth = 6;
			EmployerID.Name = "EmployerID";
			EmployerID.ReadOnly = true;
			EmployerID.Width = 125;
			// 
			// EmployerUIFReferenceNo
			// 
			EmployerUIFReferenceNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			EmployerUIFReferenceNo.HeaderText = "UIFReferenceNo";
			EmployerUIFReferenceNo.MaxInputLength = 9;
			EmployerUIFReferenceNo.MinimumWidth = 6;
			EmployerUIFReferenceNo.Name = "EmployerUIFReferenceNo";
			EmployerUIFReferenceNo.Width = 145;
			// 
			// PAYENumber
			// 
			PAYENumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			PAYENumber.HeaderText = "PAYENumber";
			PAYENumber.MaxInputLength = 10;
			PAYENumber.MinimumWidth = 6;
			PAYENumber.Name = "PAYENumber";
			PAYENumber.Width = 124;
			// 
			// TotalGrossTaxableRemuneration
			// 
			TotalGrossTaxableRemuneration.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "N2";
			dataGridViewCellStyle1.NullValue = null;
			TotalGrossTaxableRemuneration.DefaultCellStyle = dataGridViewCellStyle1;
			TotalGrossTaxableRemuneration.HeaderText = "TotalGrossTaxableRemuneration";
			TotalGrossTaxableRemuneration.MinimumWidth = 6;
			TotalGrossTaxableRemuneration.Name = "TotalGrossTaxableRemuneration";
			TotalGrossTaxableRemuneration.Width = 250;
			// 
			// TotalGrossRemunerationSubjectToUIF
			// 
			TotalGrossRemunerationSubjectToUIF.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N2";
			dataGridViewCellStyle2.NullValue = null;
			TotalGrossRemunerationSubjectToUIF.DefaultCellStyle = dataGridViewCellStyle2;
			TotalGrossRemunerationSubjectToUIF.HeaderText = "TotalGrossRemunerationSubjectToUIF";
			TotalGrossRemunerationSubjectToUIF.MinimumWidth = 6;
			TotalGrossRemunerationSubjectToUIF.Name = "TotalGrossRemunerationSubjectToUIF";
			TotalGrossRemunerationSubjectToUIF.Width = 286;
			// 
			// TotalContributions
			// 
			TotalContributions.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N2";
			dataGridViewCellStyle3.NullValue = null;
			TotalContributions.DefaultCellStyle = dataGridViewCellStyle3;
			TotalContributions.HeaderText = "TotalContributions";
			TotalContributions.MinimumWidth = 6;
			TotalContributions.Name = "TotalContributions";
			TotalContributions.Width = 160;
			// 
			// TotalEmployees
			// 
			TotalEmployees.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N0";
			dataGridViewCellStyle4.NullValue = null;
			TotalEmployees.DefaultCellStyle = dataGridViewCellStyle4;
			TotalEmployees.HeaderText = "TotalEmployees";
			TotalEmployees.MaxInputLength = 15;
			TotalEmployees.MinimumWidth = 6;
			TotalEmployees.Name = "TotalEmployees";
			TotalEmployees.Width = 143;
			// 
			// EmployerEmailAddress
			// 
			EmployerEmailAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			EmployerEmailAddress.HeaderText = "EmployerEmailAddress";
			EmployerEmailAddress.MaxInputLength = 50;
			EmployerEmailAddress.MinimumWidth = 6;
			EmployerEmailAddress.Name = "EmployerEmailAddress";
			EmployerEmailAddress.Width = 191;
			// 
			// tabControl
			// 
			tabControl.Controls.Add(creatorTab);
			tabControl.Controls.Add(employeeTab);
			tabControl.Controls.Add(employerTab);
			tabControl.Dock = DockStyle.Fill;
			tabControl.Location = new Point(0, 28);
			tabControl.Name = "tabControl";
			tabControl.SelectedIndex = 0;
			tabControl.Size = new Size(1519, 649);
			tabControl.TabIndex = 3;
			// 
			// creatorTab
			// 
			creatorTab.Controls.Add(tableLayoutPanel1);
			creatorTab.Location = new Point(4, 29);
			creatorTab.Name = "creatorTab";
			creatorTab.Padding = new Padding(3);
			creatorTab.Size = new Size(1511, 616);
			creatorTab.TabIndex = 0;
			creatorTab.Text = "Creator";
			creatorTab.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(payrollMonthDatePicker, 1, 4);
			tableLayoutPanel1.Controls.Add(contactTelephoneNoLabel, 0, 2);
			tableLayoutPanel1.Controls.Add(uifReferenceNoLabel, 0, 0);
			tableLayoutPanel1.Controls.Add(contactPersonLabel, 0, 1);
			tableLayoutPanel1.Controls.Add(contactEmailAddressLabel, 0, 3);
			tableLayoutPanel1.Controls.Add(payrollMonthLabel, 0, 4);
			tableLayoutPanel1.Controls.Add(uifReferenceNoTextBox, 1, 0);
			tableLayoutPanel1.Controls.Add(contactPersonTextBox, 1, 1);
			tableLayoutPanel1.Controls.Add(contactTelephoneNoTextBox, 1, 2);
			tableLayoutPanel1.Controls.Add(contactEmailAddressTextBox, 1, 3);
			tableLayoutPanel1.Location = new Point(8, 6);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.Size = new Size(442, 200);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// payrollMonthDatePicker
			// 
			payrollMonthDatePicker.CustomFormat = "yyyy-MM";
			payrollMonthDatePicker.Dock = DockStyle.Fill;
			payrollMonthDatePicker.Format = DateTimePickerFormat.Custom;
			payrollMonthDatePicker.Location = new Point(224, 163);
			payrollMonthDatePicker.Name = "payrollMonthDatePicker";
			payrollMonthDatePicker.ShowUpDown = true;
			payrollMonthDatePicker.Size = new Size(215, 27);
			payrollMonthDatePicker.TabIndex = 2;
			payrollMonthDatePicker.Value = new DateTime(2025, 6, 1, 0, 0, 0, 0);
			// 
			// contactTelephoneNoLabel
			// 
			contactTelephoneNoLabel.AutoSize = true;
			contactTelephoneNoLabel.Location = new Point(3, 80);
			contactTelephoneNoLabel.Name = "contactTelephoneNoLabel";
			contactTelephoneNoLabel.Size = new Size(157, 20);
			contactTelephoneNoLabel.TabIndex = 2;
			contactTelephoneNoLabel.Text = "Contact Telephone No";
			// 
			// uifReferenceNoLabel
			// 
			uifReferenceNoLabel.AutoSize = true;
			uifReferenceNoLabel.Dock = DockStyle.Fill;
			uifReferenceNoLabel.Location = new Point(3, 0);
			uifReferenceNoLabel.Name = "uifReferenceNoLabel";
			uifReferenceNoLabel.Size = new Size(215, 40);
			uifReferenceNoLabel.TabIndex = 0;
			uifReferenceNoLabel.Text = "UIF Reference No";
			// 
			// contactPersonLabel
			// 
			contactPersonLabel.AutoSize = true;
			contactPersonLabel.Location = new Point(3, 40);
			contactPersonLabel.Name = "contactPersonLabel";
			contactPersonLabel.Size = new Size(107, 20);
			contactPersonLabel.TabIndex = 1;
			contactPersonLabel.Text = "Contact Person";
			// 
			// contactEmailAddressLabel
			// 
			contactEmailAddressLabel.AutoSize = true;
			contactEmailAddressLabel.Location = new Point(3, 120);
			contactEmailAddressLabel.Name = "contactEmailAddressLabel";
			contactEmailAddressLabel.Size = new Size(158, 20);
			contactEmailAddressLabel.TabIndex = 3;
			contactEmailAddressLabel.Text = "Contact Email Address";
			// 
			// payrollMonthLabel
			// 
			payrollMonthLabel.AutoSize = true;
			payrollMonthLabel.Location = new Point(3, 160);
			payrollMonthLabel.Name = "payrollMonthLabel";
			payrollMonthLabel.Size = new Size(100, 20);
			payrollMonthLabel.TabIndex = 4;
			payrollMonthLabel.Text = "Payroll Month";
			// 
			// uifReferenceNoTextBox
			// 
			uifReferenceNoTextBox.Dock = DockStyle.Fill;
			uifReferenceNoTextBox.Location = new Point(224, 3);
			uifReferenceNoTextBox.Name = "uifReferenceNoTextBox";
			uifReferenceNoTextBox.Size = new Size(215, 27);
			uifReferenceNoTextBox.TabIndex = 5;
			// 
			// contactPersonTextBox
			// 
			contactPersonTextBox.Dock = DockStyle.Fill;
			contactPersonTextBox.Location = new Point(224, 43);
			contactPersonTextBox.Name = "contactPersonTextBox";
			contactPersonTextBox.Size = new Size(215, 27);
			contactPersonTextBox.TabIndex = 6;
			// 
			// contactTelephoneNoTextBox
			// 
			contactTelephoneNoTextBox.Dock = DockStyle.Fill;
			contactTelephoneNoTextBox.Location = new Point(224, 83);
			contactTelephoneNoTextBox.Name = "contactTelephoneNoTextBox";
			contactTelephoneNoTextBox.Size = new Size(215, 27);
			contactTelephoneNoTextBox.TabIndex = 7;
			// 
			// contactEmailAddressTextBox
			// 
			contactEmailAddressTextBox.Dock = DockStyle.Fill;
			contactEmailAddressTextBox.Location = new Point(224, 123);
			contactEmailAddressTextBox.Name = "contactEmailAddressTextBox";
			contactEmailAddressTextBox.Size = new Size(215, 27);
			contactEmailAddressTextBox.TabIndex = 8;
			// 
			// employeeTab
			// 
			employeeTab.Controls.Add(employeeDataGrid);
			employeeTab.Location = new Point(4, 29);
			employeeTab.Name = "employeeTab";
			employeeTab.Padding = new Padding(3);
			employeeTab.Size = new Size(1511, 616);
			employeeTab.TabIndex = 1;
			employeeTab.Text = "Employee";
			employeeTab.UseVisualStyleBackColor = true;
			// 
			// employeeDataGrid
			// 
			employeeDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			employeeDataGrid.Columns.AddRange(new DataGridViewColumn[] { EmployeeEmployerID, EmployeeUIFReferenceNo, IDNumber, OtherNumber, AlternateNumber, Surname, FirstNames, DateOfBirth, DateEmployedFrom, DateEmployedTo, EmploymentStatus, GrossTaxableRemuneration, RemunerationSubjectToUIF, UIFContribution, ReasonForNonContribution, BankBranchCode, BankAccountNo, BankAccountType });
			employeeDataGrid.Dock = DockStyle.Fill;
			employeeDataGrid.Location = new Point(3, 3);
			employeeDataGrid.Name = "employeeDataGrid";
			employeeDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			employeeDataGrid.Size = new Size(1505, 610);
			employeeDataGrid.TabIndex = 1;
			// 
			// EmployeeEmployerID
			// 
			EmployeeEmployerID.HeaderText = "EmployerID";
			EmployeeEmployerID.MinimumWidth = 6;
			EmployeeEmployerID.Name = "EmployeeEmployerID";
			EmployeeEmployerID.ToolTipText = "The ID corresponding to an employer from the grid in the Employer tab.";
			EmployeeEmployerID.Width = 125;
			// 
			// EmployeeUIFReferenceNo
			// 
			EmployeeUIFReferenceNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			EmployeeUIFReferenceNo.HeaderText = "UIFReferenceNo";
			EmployeeUIFReferenceNo.MaxInputLength = 9;
			EmployeeUIFReferenceNo.MinimumWidth = 6;
			EmployeeUIFReferenceNo.Name = "EmployeeUIFReferenceNo";
			EmployeeUIFReferenceNo.Width = 145;
			// 
			// IDNumber
			// 
			IDNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			IDNumber.HeaderText = "IDNumber";
			IDNumber.MaxInputLength = 13;
			IDNumber.MinimumWidth = 6;
			IDNumber.Name = "IDNumber";
			IDNumber.ToolTipText = "Valid 13 digit bar coded RSA national ID number";
			IDNumber.Width = 107;
			// 
			// OtherNumber
			// 
			OtherNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			OtherNumber.HeaderText = "OtherNumber";
			OtherNumber.MaxInputLength = 16;
			OtherNumber.MinimumWidth = 6;
			OtherNumber.Name = "OtherNumber";
			OtherNumber.ToolTipText = "Passport number, residence permit, old national ID number, etc.";
			OtherNumber.Width = 129;
			// 
			// AlternateNumber
			// 
			AlternateNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			AlternateNumber.HeaderText = "AlternateNumber";
			AlternateNumber.MaxInputLength = 25;
			AlternateNumber.MinimumWidth = 6;
			AlternateNumber.Name = "AlternateNumber";
			AlternateNumber.ToolTipText = "Personnel, clock card, or payroll number";
			AlternateNumber.Width = 153;
			// 
			// Surname
			// 
			Surname.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			Surname.HeaderText = "Surname";
			Surname.MaxInputLength = 120;
			Surname.MinimumWidth = 6;
			Surname.Name = "Surname";
			Surname.Width = 96;
			// 
			// FirstNames
			// 
			FirstNames.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			FirstNames.HeaderText = "FirstNames";
			FirstNames.MaxInputLength = 90;
			FirstNames.MinimumWidth = 6;
			FirstNames.Name = "FirstNames";
			FirstNames.Width = 111;
			// 
			// DateOfBirth
			// 
			DateOfBirth.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			DateOfBirth.HeaderText = "DateOfBirth";
			DateOfBirth.MinimumWidth = 6;
			DateOfBirth.Name = "DateOfBirth";
			DateOfBirth.Resizable = DataGridViewTriState.True;
			DateOfBirth.Width = 117;
			// 
			// DateEmployedFrom
			// 
			DateEmployedFrom.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			DateEmployedFrom.HeaderText = "DateEmployedFrom";
			DateEmployedFrom.MinimumWidth = 6;
			DateEmployedFrom.Name = "DateEmployedFrom";
			DateEmployedFrom.ToolTipText = "The latest date that the employee started work at the employer";
			DateEmployedFrom.Width = 171;
			// 
			// DateEmployedTo
			// 
			DateEmployedTo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			DateEmployedTo.HeaderText = "DateEmployedTo";
			DateEmployedTo.MinimumWidth = 6;
			DateEmployedTo.Name = "DateEmployedTo";
			DateEmployedTo.ToolTipText = "Employee termination of services date. Required if any other employment status is selected.";
			DateEmployedTo.Width = 153;
			// 
			// EmploymentStatus
			// 
			EmploymentStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			EmploymentStatus.HeaderText = "EmploymentStatus";
			EmploymentStatus.MinimumWidth = 6;
			EmploymentStatus.Name = "EmploymentStatus";
			EmploymentStatus.Width = 139;
			// 
			// GrossTaxableRemuneration
			// 
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N2";
			dataGridViewCellStyle5.NullValue = "0.00";
			GrossTaxableRemuneration.DefaultCellStyle = dataGridViewCellStyle5;
			GrossTaxableRemuneration.HeaderText = "GrossTaxableRemuneration";
			GrossTaxableRemuneration.MinimumWidth = 6;
			GrossTaxableRemuneration.Name = "GrossTaxableRemuneration";
			GrossTaxableRemuneration.ToolTipText = "This must be accumulated from the same remuneration amounts that make up the total reflected on the SARS tax certificate under code 3699";
			GrossTaxableRemuneration.Width = 125;
			// 
			// RemunerationSubjectToUIF
			// 
			RemunerationSubjectToUIF.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N2";
			dataGridViewCellStyle6.NullValue = "0.00";
			RemunerationSubjectToUIF.DefaultCellStyle = dataGridViewCellStyle6;
			RemunerationSubjectToUIF.HeaderText = "RemunerationSubjectToUIF";
			RemunerationSubjectToUIF.MinimumWidth = 6;
			RemunerationSubjectToUIF.Name = "RemunerationSubjectToUIF";
			RemunerationSubjectToUIF.ToolTipText = resources.GetString("RemunerationSubjectToUIF.ToolTipText");
			RemunerationSubjectToUIF.Width = 217;
			// 
			// UIFContribution
			// 
			UIFContribution.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N2";
			dataGridViewCellStyle7.NullValue = "0.00";
			UIFContribution.DefaultCellStyle = dataGridViewCellStyle7;
			UIFContribution.HeaderText = "UIFContribution";
			UIFContribution.MinimumWidth = 6;
			UIFContribution.Name = "UIFContribution";
			UIFContribution.ToolTipText = "The total of the employer and employee UIF contribution in respect of the employee. If present, this amount must be 2% of the remuneration subject to UIF";
			UIFContribution.Width = 142;
			// 
			// ReasonForNonContribution
			// 
			ReasonForNonContribution.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			ReasonForNonContribution.HeaderText = "ReasonForNonContribution";
			ReasonForNonContribution.MinimumWidth = 6;
			ReasonForNonContribution.Name = "ReasonForNonContribution";
			ReasonForNonContribution.ToolTipText = "This field is required if the UIF contribution amount is zero";
			ReasonForNonContribution.Width = 195;
			// 
			// BankBranchCode
			// 
			BankBranchCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			BankBranchCode.HeaderText = "BankBranchCode";
			BankBranchCode.MinimumWidth = 6;
			BankBranchCode.Name = "BankBranchCode";
			BankBranchCode.Width = 150;
			// 
			// BankAccountNo
			// 
			BankAccountNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			BankAccountNo.HeaderText = "BankAccountNo";
			BankAccountNo.MinimumWidth = 6;
			BankAccountNo.Name = "BankAccountNo";
			BankAccountNo.Width = 144;
			// 
			// BankAccountType
			// 
			BankAccountType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			BankAccountType.HeaderText = "BankAccountType";
			BankAccountType.MinimumWidth = 6;
			BankAccountType.Name = "BankAccountType";
			BankAccountType.Width = 132;
			// 
			// employerTab
			// 
			employerTab.Controls.Add(employerDataGrid);
			employerTab.Location = new Point(4, 29);
			employerTab.Name = "employerTab";
			employerTab.Padding = new Padding(3);
			employerTab.Size = new Size(1511, 616);
			employerTab.TabIndex = 2;
			employerTab.Text = "Employer";
			employerTab.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = SystemColors.MenuBar;
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenuItem, helpMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1519, 28);
			menuStrip1.TabIndex = 4;
			// 
			// fileMenuItem
			// 
			fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, newMenuItem, openMenuItem, toolStripSeparator2, saveMenuItem, toolStripSeparator3, exitMenuItem });
			fileMenuItem.Name = "fileMenuItem";
			fileMenuItem.Size = new Size(46, 24);
			fileMenuItem.Text = "&File";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(178, 6);
			// 
			// newMenuItem
			// 
			newMenuItem.Name = "newMenuItem";
			newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
			newMenuItem.Size = new Size(181, 26);
			newMenuItem.Text = "&New";
			newMenuItem.Click += newToolStripMenuItem_Click;
			// 
			// openMenuItem
			// 
			openMenuItem.Name = "openMenuItem";
			openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
			openMenuItem.Size = new Size(181, 26);
			openMenuItem.Text = "&Open";
			openMenuItem.Click += OpenToolStripMenuItem_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(178, 6);
			// 
			// saveMenuItem
			// 
			saveMenuItem.Name = "saveMenuItem";
			saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			saveMenuItem.Size = new Size(181, 26);
			saveMenuItem.Text = "&Save";
			saveMenuItem.Click += SaveMenuButton_Click;
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new Size(178, 6);
			// 
			// exitMenuItem
			// 
			exitMenuItem.Name = "exitMenuItem";
			exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
			exitMenuItem.Size = new Size(181, 26);
			exitMenuItem.Text = "E&xit";
			exitMenuItem.Click += ExitMenuItem_Click;
			// 
			// helpMenuItem
			// 
			helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
			helpMenuItem.Name = "helpMenuItem";
			helpMenuItem.Size = new Size(55, 24);
			helpMenuItem.Text = "&Help";
			// 
			// aboutMenuItem
			// 
			aboutMenuItem.Name = "aboutMenuItem";
			aboutMenuItem.Size = new Size(133, 26);
			aboutMenuItem.Text = "About";
			aboutMenuItem.Click += aboutMenuItem_Click;
			// 
			// UIFPayrollFileEditor
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1519, 677);
			Controls.Add(tabControl);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "UIFPayrollFileEditor";
			Text = "UIF Payroll File Editor";
			WindowState = FormWindowState.Maximized;
			FormClosing += PayrollConverterApp_FormClosing;
			((System.ComponentModel.ISupportInitialize)employerDataGrid).EndInit();
			tabControl.ResumeLayout(false);
			creatorTab.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			employeeTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)employeeDataGrid).EndInit();
			employerTab.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		// Auto-generated WinForms layout for PayrollForm
		// Paste this into your Form1.Designer.cs file inside InitializeComponent()

		private void InitializePayrollTabs()
		{
			var tabControl = new TabControl
			{
				Dock = DockStyle.Fill
			};

			var creatorTab = new TabPage("Creator");
			var employeeTab = new TabPage("Employee");
			var employerTab = new TabPage("Employer");

			tabControl.TabPages.Add(creatorTab);
			tabControl.TabPages.Add(employeeTab);
			tabControl.TabPages.Add(employerTab);

			Controls.Add(tabControl);

			// Helper function
			TableLayoutPanel CreateFormLayout() => new TableLayoutPanel
			{
				ColumnCount = 2,
				AutoSize = true,
				Dock = DockStyle.Top,
				Padding = new Padding(10),
				AutoScroll = true,
				CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
				ColumnStyles =
		{
			new ColumnStyle(SizeType.AutoSize),
			new ColumnStyle(SizeType.Percent, 100)
		}
			};

			TextBox CreateTextBox(int maxLength, bool numericOnly = false)
			{
				var tb = new TextBox
				{
					MaxLength = maxLength,
					Width = 350,
					Anchor = AnchorStyles.Left | AnchorStyles.Right
				};
				if (numericOnly)
				{
					tb.KeyPress += (s, e) =>
					{
						e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
					};
				}
				return tb;
			}

			ComboBox CreateComboBox(Dictionary<string, string> items)
			{
				var cb = new ComboBox
				{
					DropDownStyle = ComboBoxStyle.DropDownList,
					Width = 350,
					Anchor = AnchorStyles.Left | AnchorStyles.Right
				};
				foreach (var kv in items)
					cb.Items.Add($"{kv.Key}: {kv.Value}");
				return cb;
			}

			void AddControl(TableLayoutPanel panel, string labelText, Control control, string tooltip = null)
			{
				var label = new Label
				{
					Text = labelText,
					AutoSize = true,
					Width = 200,
					Anchor = AnchorStyles.Left | AnchorStyles.Right
				};
				if (!string.IsNullOrEmpty(tooltip))
				{
					new ToolTip().SetToolTip(control, tooltip);
				}
				panel.Controls.Add(label);
				panel.Controls.Add(control);
			}

			DataGridView CreateGridView()
			{
				return new DataGridView
				{
					Dock = DockStyle.Fill,
					AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
					AllowUserToAddRows = false,
					ReadOnly = true,
					SelectionMode = DataGridViewSelectionMode.FullRowSelect
				};
			}

			Button CreateAddButton(string text, EventHandler onClick)
			{
				return new Button
				{
					Text = text,
					Dock = DockStyle.Top,
					Height = 40
				};
			}

			// CREATOR TAB
			var creatorLayout = CreateFormLayout();
			var creatorFields = new List<Control>();
			void AddCreatorField(string label, Control control)
			{
				creatorFields.Add(control);
				AddControl(creatorLayout, label, control);
			}
			AddCreatorField("UIF Reference Number", CreateTextBox(9));
			AddCreatorField("Contact Person", CreateTextBox(30));
			AddCreatorField("Contact Telephone Number", CreateTextBox(16));
			AddCreatorField("Contact Email Address", CreateTextBox(50));
			var payrollMonthPicker = new DateTimePicker
			{
				Format = DateTimePickerFormat.Custom,
				CustomFormat = "yyyy-MM",
				ShowUpDown = true,
				Width = 350,
				Anchor = AnchorStyles.Left | AnchorStyles.Right
			};
			AddCreatorField("Payroll Month", payrollMonthPicker);
			creatorTab.Controls.Add(creatorLayout);
			var creatorGrid = CreateGridView();
			creatorTab.Controls.Add(creatorGrid);
			creatorTab.Controls.Add(CreateAddButton("Add Creator Entry", (s, e) =>
			{
				var index = creatorGrid.Rows.Add();
				for (int i = 0; i < creatorFields.Count; i++)
				{
					if (creatorGrid.Columns.Count < creatorFields.Count)
						creatorGrid.Columns.Add($"col{i}", ((Label)creatorLayout.Controls[i * 2]).Text);
					creatorGrid.Rows[index].Cells[i].Value = (creatorFields[i] as TextBox)?.Text ?? (creatorFields[i] as DateTimePicker)?.Value.ToString("yyyy-MM") ?? string.Empty;
				}
			}));

			// EMPLOYEE TAB
			var empLayout = CreateFormLayout();
			var employeeFields = new List<Control>();
			void AddEmployeeField(string label, Control control, string tooltip = null)
			{
				employeeFields.Add(control);
				AddControl(empLayout, label, control, tooltip);
			}

			AddEmployeeField("UIF Reference Number", CreateTextBox(9));
			AddEmployeeField("ID Number", CreateTextBox(13, true));
			AddEmployeeField("Other Number", CreateTextBox(16), "Passport number, residence permit, old national ID number, etc");
			AddEmployeeField("Alternate Number", CreateTextBox(25), "Personnel, clock card, or payroll number");
			AddEmployeeField("Surname", CreateTextBox(120));
			AddEmployeeField("First Names", CreateTextBox(90));
			AddEmployeeField("Date of Birth", new DateTimePicker { Width = 350, Anchor = AnchorStyles.Left | AnchorStyles.Right });
			AddEmployeeField("Date Employed From", new DateTimePicker { Width = 350, Anchor = AnchorStyles.Left | AnchorStyles.Right });
			AddEmployeeField("Date Employed To", new DateTimePicker { Width = 350, Anchor = AnchorStyles.Left | AnchorStyles.Right });

			var employmentStatuses = new Dictionary<string, string>
			{
				["01"] = "Active",
				["02"] = "Deceased",
				["03"] = "Retired",
				["04"] = "Dismissed",
				["05"] = "Contract Expired",
				["06"] = "Resigned",
				["07"] = "Constructively Dismissed",
				["08"] = "Employers Insolvency",
				["09"] = "Maternity / Adoption Leave",
				["10"] = "Illness Leave",
				["11"] = "Retrenched",
				["12"] = "Transfer to another branch",
				["13"] = "Absconded",
				["14"] = "Business Closed",
				["15"] = "Death of Domestic Employer",
				["16"] = "Voluntary Severance Package",
				["17"] = "Reduced Working Time",
				["19"] = "Parental Leave"
			};
			AddEmployeeField("Employment Status", CreateComboBox(employmentStatuses));

			var nonContrib = new Dictionary<string, string>
			{
				["01"] = "Temporary employees (less than 24 hours per month)",
				["02"] = "Learners in terms of the skills development act",
				["03"] = "Employees in the national and provincial spheres of government",
				["04"] = "Employees who are repatriated at the end of their contract of service",
				["05"] = "Employees who earn commission only",
				["06"] = "No income paid for the payroll period"
			};
			var reasonCombo = CreateComboBox(nonContrib);
			AddEmployeeField("Reason for Non-Contribution", reasonCombo);
			empLayout.Controls[empLayout.Controls.Count - 2].Visible = false; // label
			reasonCombo.Visible = false;

			var uifContributionBox = CreateTextBox(13, true);
			uifContributionBox.TextChanged += (s, e) =>
			{
				bool isZero = decimal.TryParse(uifContributionBox.Text, out var val) && val == 0;
				reasonCombo.Visible = empLayout.Controls[empLayout.Controls.IndexOf(reasonCombo) - 1].Visible = isZero;
			};
			AddEmployeeField("Gross Taxable Remuneration", CreateTextBox(13, true));
			AddEmployeeField("Remuneration Subject To UIF", CreateTextBox(13, true));
			AddEmployeeField("UIF Contribution", uifContributionBox);
			AddEmployeeField("Bank Branch Code", CreateTextBox(8, true));
			AddEmployeeField("Bank Account Number", CreateTextBox(16, true));

			var acctTypes = new Dictionary<string, string>
			{
				["1"] = "Current (Cheque) account",
				["2"] = "Savings account",
				["3"] = "Transmission account",
				["4"] = "Bond account",
				["6"] = "Subscription Share account"
			};
			AddEmployeeField("Bank Account Type", CreateComboBox(acctTypes));

			employeeTab.Controls.Add(empLayout);
			var employeeGrid = CreateGridView();
			employeeTab.Controls.Add(employeeGrid);
			employeeTab.Controls.Add(CreateAddButton("Add Employee Entry", (s, e) =>
			{
				var index = employeeGrid.Rows.Add();
				for (int i = 0; i < employeeFields.Count; i++)
				{
					if (employeeGrid.Columns.Count < employeeFields.Count)
						employeeGrid.Columns.Add($"col{i}", ((Label)empLayout.Controls[i * 2]).Text);
					var ctrl = employeeFields[i];
					employeeGrid.Rows[index].Cells[i].Value = (ctrl as TextBox)?.Text ?? (ctrl as DateTimePicker)?.Value.ToShortDateString() ?? (ctrl as ComboBox)?.Text ?? string.Empty;
				}
			}));

			// EMPLOYER TAB
			var erLayout = CreateFormLayout();
			var employerFields = new List<Control>();
			void AddEmployerField(string label, Control control)
			{
				employerFields.Add(control);
				AddControl(erLayout, label, control);
			}
			AddEmployerField("UIF Reference Number", CreateTextBox(9));
			AddEmployerField("PAYE Number", CreateTextBox(10, true));
			AddEmployerField("Total Gross Taxable Renumeration", CreateTextBox(13, true));
			AddEmployerField("Total Gross Remuneration subject to UIF", CreateTextBox(13, true));
			AddEmployerField("Total Contributions", CreateTextBox(13, true));
			AddEmployerField("Total Employees", CreateTextBox(15, true));
			AddEmployerField("Employer's Email Address", CreateTextBox(50));
			employerTab.Controls.Add(erLayout);
			var employerGrid = CreateGridView();
			employerTab.Controls.Add(employerGrid);
			employerTab.Controls.Add(CreateAddButton("Add Employer Entry", (s, e) =>
			{
				var index = employerGrid.Rows.Add();
				for (int i = 0; i < employerFields.Count; i++)
				{
					if (employerGrid.Columns.Count < employerFields.Count)
						employerGrid.Columns.Add($"col{i}", ((Label)erLayout.Controls[i * 2]).Text);
					employerGrid.Rows[index].Cells[i].Value = (employerFields[i] as TextBox)?.Text ?? (employerFields[i] as DateTimePicker)?.Value.ToShortDateString() ?? string.Empty;
				}
			}));
		}

		#endregion
		private DataGridView employerDataGrid;
		private TabControl tabControl;
		private TabPage creatorTab;
		private TabPage employeeTab;
		private DataGridView employeeDataGrid;
		private TabPage employerTab;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileMenuItem;
		private ToolStripMenuItem saveMenuItem;
		private ToolStripMenuItem newMenuItem;
		private ToolStripMenuItem openMenuItem;
		private DataGridViewTextBoxColumn EmployerID;
		private DataGridViewTextBoxColumn EmployerUIFReferenceNo;
		private DataGridViewTextBoxColumn PAYENumber;
		private DataGridViewTextBoxColumn TotalGrossTaxableRemuneration;
		private DataGridViewTextBoxColumn TotalGrossRemunerationSubjectToUIF;
		private DataGridViewTextBoxColumn TotalContributions;
		private DataGridViewTextBoxColumn TotalEmployees;
		private DataGridViewTextBoxColumn EmployerEmailAddress;
		private ToolStripMenuItem helpMenuItem;
		private ToolStripMenuItem aboutMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripMenuItem exitMenuItem;
		private DataGridViewTextBoxColumn EmployeeEmployerID;
		private DataGridViewTextBoxColumn EmployeeUIFReferenceNo;
		private DataGridViewTextBoxColumn IDNumber;
		private DataGridViewTextBoxColumn OtherNumber;
		private DataGridViewTextBoxColumn AlternateNumber;
		private DataGridViewTextBoxColumn Surname;
		private DataGridViewTextBoxColumn FirstNames;
		private DataGridViewTextBoxColumn DateOfBirth;
		private DataGridViewTextBoxColumn DateEmployedFrom;
		private DataGridViewTextBoxColumn DateEmployedTo;
		private DataGridViewComboBoxColumn EmploymentStatus;
		private DataGridViewTextBoxColumn GrossTaxableRemuneration;
		private DataGridViewTextBoxColumn RemunerationSubjectToUIF;
		private DataGridViewTextBoxColumn UIFContribution;
		private DataGridViewComboBoxColumn ReasonForNonContribution;
		private DataGridViewTextBoxColumn BankBranchCode;
		private DataGridViewTextBoxColumn BankAccountNo;
		private DataGridViewComboBoxColumn BankAccountType;
		private TableLayoutPanel tableLayoutPanel1;
		private Label contactTelephoneNoLabel;
		private Label uifReferenceNoLabel;
		private Label contactPersonLabel;
		private Label contactEmailAddressLabel;
		private Label payrollMonthLabel;
		private TextBox uifReferenceNoTextBox;
		private TextBox contactPersonTextBox;
		private TextBox contactTelephoneNoTextBox;
		private TextBox contactEmailAddressTextBox;
		private DateTimePicker payrollMonthDatePicker;
	}
}
