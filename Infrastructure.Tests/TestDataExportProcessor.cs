using Core.Models;
using Infrastructure.Export;
using NUnit.Framework;

namespace Infrastructure.Tests
{
	[TestFixture]
	public class TestDataExportProcessor
	{
		[Test]
		public void Process_EmptyLists_ReturnsEmptyArray()
		{
			var result = DataExportProcessor.Process(
				Enumerable.Empty<Creator>(),
				Enumerable.Empty<Employee>(),
				Enumerable.Empty<Employer>());

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void Process_SingleCreatorEmployeeEmployer_ExportsCorrectly()
		{
			var creators = new List<Creator>
			{
				new Creator
				{
					CreatorUIFReferenceNo = "123456789",
					ContactPerson = "John Doe",
					ContactTelephoneNo = "0123456789",
					ContactEmailAddress = "john@example.com",
					PayrollMonth = "202406"
				}
			};
			var employees = new List<Employee>
			{
				new Employee
				{
					EmployerID = 1,
					EmployeeUIFReferenceNo = "987654321",
					IDNumber = "8001015009087",
					Surname = "Smith",
					FirstNames = "Jane",
					DateOfBirth = "19800101",
					GrossTaxableRemuneration = 1234.56m,
					RemunerationSubjectToUIF = 1200.00m,
					UIFContribution = 12.34m,
					BankBranchCode = "123456",
					BankAccountNo = "1234567890",
					BankAccountType = "01"
				}
			};
			var employers = new List<Employer>
			{
				new Employer
				{
					EmployerID = 1,
					EmployerUIFReferenceNo = "111222333",
					PAYENumber = "1234567890",
					TotalGrossTaxableRemuneration = 1234.56m,
					TotalGrossRemunerationSubjectToUIF = 1200.00m,
					TotalContributions = 12.34m,
					TotalEmployees = 1,
					EmployerEmailAddress = "employer@example.com"
				}
			};

			var result = DataExportProcessor.Process(creators, employees, employers);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Length, Is.EqualTo(3)); // 1 creator + 1 employee (employer row is not output until next employee/employer)

			Assert.That(result[0], Does.Contain("8000").And.Contain("123456789"));
			Assert.That(result[1], Does.Contain("8001").And.Contain("987654321"));
			Assert.That(result[2], Does.Contain("8002").And.Contain("111222333"));
		}

		[Test]
		public void Process_MultipleEmployeesAndEmployers_ExportsInOrder()
		{
			var creators = new List<Creator>
			{
				new Creator { CreatorUIFReferenceNo = "123456789" }
			};
			var employees = new List<Employee>
			{
				new Employee { EmployerID = 1, EmployeeUIFReferenceNo = "E1" },
				new Employee { EmployerID = 2, EmployeeUIFReferenceNo = "E2" }
			};
			var employers = new List<Employer>
			{
				new Employer { EmployerID = 1, EmployerUIFReferenceNo = "EMP1" },
				new Employer { EmployerID = 2, EmployerUIFReferenceNo = "EMP2" }
			};

			var result = DataExportProcessor.Process(creators, employees, employers);

			// Should be: creator, employee1, employer1, employee2, employer2
			Assert.That(result.Length, Is.EqualTo(5));
			Assert.That(result[0], Does.Contain("8000"));
			Assert.That(result[1], Does.Contain("8001").And.Contain("E1"));
			Assert.That(result[2], Does.Contain("8002").And.Contain("EMP1"));
			Assert.That(result[3], Does.Contain("8001").And.Contain("E2"));
			Assert.That(result[4], Does.Contain("8002").And.Contain("EMP2"));
		}

		[Test]
		public void Process_ZeroAmounts_ExcludesAmountFields()
		{
			var creators = new List<Creator>
			{
				new Creator { CreatorUIFReferenceNo = "123456789" }
			};
			var employees = new List<Employee>
			{
				new Employee
				{
					EmployerID = 1,
					EmployeeUIFReferenceNo = "E1",
					GrossTaxableRemuneration = 0,
					RemunerationSubjectToUIF = 0,
					UIFContribution = 0
				}
			};
			var employers = new List<Employer>
			{
				new Employer
				{
					EmployerID = 1,
					EmployerUIFReferenceNo = "EMP1",
					TotalGrossTaxableRemuneration = 0,
					TotalGrossRemunerationSubjectToUIF = 0,
					TotalContributions = 0
				}
			};

			var result = DataExportProcessor.Process(creators, employees, employers);

			// Amount fields should not be present (no "8300", "8310", "8320", "8130", "8135", "8140")
			Assert.That(result[1], Does.Not.Contain("8300").And.Not.Contain("8310").And.Not.Contain("8320"));
			Assert.That(result.Last(), Does.Not.Contain("8130").And.Not.Contain("8135").And.Not.Contain("8140"));
		}

		[Test]
		public void Process_ZeroFillStringFields_PadsCorrectly()
		{
			var creators = new List<Creator>
			{
				new Creator { CreatorUIFReferenceNo = "1" }
			};
			var employees = new List<Employee>
			{
				new Employee { EmployerID = 1, EmployeeUIFReferenceNo = "2" }
			};
			var employers = new List<Employer>
			{
				new Employer { EmployerID = 1, EmployerUIFReferenceNo = "3" }
			};

			var result = DataExportProcessor.Process(creators, employees, employers);

			// CreatorUIFReferenceNo, EmployeeUIFReferenceNo, EmployerUIFReferenceNo should be zero-padded to 9 digits
			Assert.That(result[0], Does.Contain("\"000000001\""));
			Assert.That(result[1], Does.Contain("\"000000002\""));
			Assert.That(result.Last(), Does.Contain("\"000000003\""));
		}
	}
}
