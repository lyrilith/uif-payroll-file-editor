using Infrastructure.Import;
using NUnit.Framework;

namespace Infrastructure.Tests
{
	[TestFixture]
	public class TestDataImportProcessor
	{
		[Test]
		public void ImportModelsFromCsv_EmptyInput_ReturnsEmptyLists()
		{
			var result = DataImportProcessor.ImportModelsFromCsv([]);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Creators, Is.Empty);
			Assert.That(result.Employees, Is.Empty);
			Assert.That(result.Employers, Is.Empty);
		}

		[Test]
		public void ImportModelsFromCsv_SingleCreatorEmployeeEmployer_ParsesCorrectly()
		{
			var csvLines = new[]
			{
                // Creator
                "\"8000\",\"UICR\",\"8010\",\"U1\",\"8015\",\"E03\",\"8020\",\"123456789\",\"8030\",\"LIVE\",\"8040\",\"John Doe\",\"8050\",\"0123456789\",\"8060\",\"john@example.com\",\"8070\",\"202406\"",
                // Employee
                "\"8001\",\"UIWK\",\"8110\",\"987654321\",\"8200\",\"8001015009087\",\"8230\",\"Smith\",\"8240\",\"Jane\",\"8250\",\"19800101\",\"8300\",\"1234.56\",\"8310\",\"1200.00\",\"8320\",\"12.34\",\"8330\",\"123456\",\"8340\",\"1234567890\",\"8350\",\"01\"",
                // Employer
                "\"8002\",\"UIEM\",\"8115\",\"111222333\",\"8120\",\"1234567890\",\"8130\",\"1234.56\",\"8135\",\"1200.00\",\"8140\",\"12.34\",\"8150\",\"1\",\"8160\",\"employer@example.com\""
			};

			var result = DataImportProcessor.ImportModelsFromCsv(csvLines);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Creators.Count, Is.EqualTo(1));
			Assert.That(result.Employees.Count, Is.EqualTo(1));
			Assert.That(result.Employers.Count, Is.EqualTo(1));

			var creator = result.Creators[0];
			Assert.That(creator.CreatorUIFReferenceNo, Is.EqualTo("123456789"));
			Assert.That(creator.ContactPerson, Is.EqualTo("John Doe"));
			Assert.That(creator.ContactTelephoneNo, Is.EqualTo("0123456789"));
			Assert.That(creator.ContactEmailAddress, Is.EqualTo("john@example.com"));
			Assert.That(creator.PayrollMonth, Is.EqualTo(new DateTime(2024, 06, 01)));

			var employee = result.Employees[0];
			Assert.That(employee.EmployeeUIFReferenceNo, Is.EqualTo("987654321"));
			Assert.That(employee.IDNumber, Is.EqualTo("8001015009087"));
			Assert.That(employee.Surname, Is.EqualTo("Smith"));
			Assert.That(employee.FirstNames, Is.EqualTo("Jane"));
			Assert.That(employee.DateOfBirth, Is.EqualTo("19800101"));
			Assert.That(employee.GrossTaxableRemuneration, Is.EqualTo(1234.56m));
			Assert.That(employee.RemunerationSubjectToUIF, Is.EqualTo(1200.00m));
			Assert.That(employee.UIFContribution, Is.EqualTo(12.34m));
			Assert.That(employee.BankBranchCode, Is.EqualTo("123456"));
			Assert.That(employee.BankAccountNo, Is.EqualTo("1234567890"));
			Assert.That(employee.BankAccountType, Is.EqualTo("01"));

			var employer = result.Employers[0];
			Assert.That(employer.EmployerUIFReferenceNo, Is.EqualTo("111222333"));
			Assert.That(employer.PAYENumber, Is.EqualTo("1234567890"));
			Assert.That(employer.TotalGrossTaxableRemuneration, Is.EqualTo(1234.56m));
			Assert.That(employer.TotalGrossRemunerationSubjectToUIF, Is.EqualTo(1200.00m));
			Assert.That(employer.TotalContributions, Is.EqualTo(12.34m));
			Assert.That(employer.TotalEmployees, Is.EqualTo(1));
			Assert.That(employer.EmployerEmailAddress, Is.EqualTo("employer@example.com"));
		}

		[Test]
		public void ImportModelsFromCsv_MultipleEmployeesAndEmployers_ParsesAll()
		{
			var csvLines = new[]
			{
                // Creator
                "\"8000\",\"UICR\",\"8020\",\"123456789\"",
                // Employee 1
                "\"8001\",\"UIWK\",\"8110\",\"E1\"",
                // Employer 1
                "\"8002\",\"UIEM\",\"8115\",\"EMP1\"",
                // Employee 2
                "\"8001\",\"UIWK\",\"8110\",\"E2\"",
                // Employer 2
                "\"8002\",\"UIEM\",\"8115\",\"EMP2\""
			};

			var result = DataImportProcessor.ImportModelsFromCsv(csvLines);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Creators.Count, Is.EqualTo(1));
			Assert.That(result.Employees.Count, Is.EqualTo(2));
			Assert.That(result.Employers.Count, Is.EqualTo(2));
			Assert.That(result.Employees[0].EmployeeUIFReferenceNo, Is.EqualTo("E1"));
			Assert.That(result.Employees[1].EmployeeUIFReferenceNo, Is.EqualTo("E2"));
			Assert.That(result.Employers[0].EmployerUIFReferenceNo, Is.EqualTo("EMP1"));
			Assert.That(result.Employers[1].EmployerUIFReferenceNo, Is.EqualTo("EMP2"));
		}

		[Test]
		public void ImportModelsFromCsv_HandlesMissingFieldsAndDefaults()
		{
			var csvLines = new[]
			{
                // Creator with only UIFReferenceNo
                "\"8000\",\"UICR\",\"8020\",\"123456789\"",
                // Employee with only UIFReferenceNo
                "\"8001\",\"UIWK\",\"8110\",\"E1\"",
                // Employer with only UIFReferenceNo
                "\"8002\",\"UIEM\",\"8115\",\"EMP1\""
			};

			var result = DataImportProcessor.ImportModelsFromCsv(csvLines);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Creators.Count, Is.EqualTo(1));
			Assert.That(result.Employees.Count, Is.EqualTo(1));
			Assert.That(result.Employers.Count, Is.EqualTo(1));
			Assert.That(result.Creators[0].CreatorUIFReferenceNo, Is.EqualTo("123456789"));
			Assert.That(result.Employees[0].EmployeeUIFReferenceNo, Is.EqualTo("E1"));
			Assert.That(result.Employers[0].EmployerUIFReferenceNo, Is.EqualTo("EMP1"));

			// Other fields should be default
			Assert.That(result.Creators[0].ContactPerson, Is.EqualTo(string.Empty));
			Assert.That(result.Employees[0].IDNumber, Is.EqualTo(string.Empty));
			Assert.That(result.Employers[0].PAYENumber, Is.EqualTo(string.Empty));
		}
	}
}
