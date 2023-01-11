using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loans.Domain.Applications;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LoansLibrary.Tests
{
    public class LoanRepaymentCalculatorShould
    {
        [Test]
        public void CalculateCorrectMonthlyRepayment()
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", 200_000), 6.5m, new LoanTerm(30));

            Assert.That(monthlyPayment, Is.EqualTo(1264.14));
        }
    }
}
