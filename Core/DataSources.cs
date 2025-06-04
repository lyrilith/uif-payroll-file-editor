namespace Core
{
	public static class DataSources
	{
		public static readonly Dictionary<string, string> BankAccountTypeDataSource = new()
		{
			["1"] = "Cheque/Current",
			["2"] = "Savings",
			["3"] = "Transmission",
			["4"] = "Bond",
			["6"] = "Subscription Share"
		};

		public static readonly Dictionary<string, string> NonContributionReasonDataSource = new()
		{
			["00"] = "",
			["01"] = "Temporary employees (less than 24 hours per month)",
			["02"] = "Learners in terms of the skills development act",
			["03"] = "Employees in the national and provincial spheres of government",
			["04"] = "Employees who are repatriated at the end of their contract of service",
			["05"] = "Employees who earn commission only",
			["06"] = "No income paid for the payroll period"
		};

		public static readonly Dictionary<string, string> EmploymentStatusDataSource = new()
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
	}
}
