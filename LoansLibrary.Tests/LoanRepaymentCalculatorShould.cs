using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loans.Domain.Applications;
using Loans.Tests;
using NUnit.Framework;

namespace LoansLibrary.Tests
{
    [TestFixture]
    public class LoanRepaymentCalculatorShould

    {
        // make data-driven test
        [Test]
        // provide method-level test data
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        public void CalculateCorrectMonthlyRepayment(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        // make data-driven test
        [Test]
        // provide method-level test data - disadvantage for test case: cannot share test data across test methods/classes
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyRepayment_SimplifiedTestCase(decimal principal, decimal interestRate, int termInYears)
        {
            var sut = new LoanRepaymentCalculator();
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }

        // make data-driven test
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public void CalculateCorrectMonthlyRepayment_Centralized(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn), "TestCases")]
        public decimal CalculateCorrectMonthlyRepayment_CentralizedWithReturn(decimal principal, decimal interestRate, int termInYears)
        {
            var sut = new LoanRepaymentCalculator();
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCases", new object[] { "Data.csv" })]
        public void CalculateCorrectMonthlyRepayment_Csv(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Combinatorial(
            [Values(100_000, 200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 20)] decimal interestRate,
            [Values(10, 20, 30)] int termInYears
            )
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }

        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyRepayment_Sequential(
        [Values(100_000, 200_000, 500_000)] decimal principal,
        [Values(6.5, 10, 20)] decimal interestRate,
        [Values(10, 20, 30)] int termInYears
        )
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Rangel(
        [Range(50_000, 1_000_000, 50_000)] decimal principal,
        [Range(0.5, 20.0, 0.5)] decimal interestRate,
        [Values(10, 20, 30)] int termInYears
        )
        {
            var sut = new LoanRepaymentCalculator();
            sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }
    }
}
