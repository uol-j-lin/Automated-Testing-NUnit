using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansLibrary.Tests
{
    [TestFixture]
    internal class LongTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            // system under test
            var sut = new LoanTerm(1);

            // use constraint model of assertions over classic model
            Assert.That(sut.ToMonths(), Is.EqualTo(12), "Months should be 12 * number of years");
        }

        [Test]
        public void StoreYears()
        {
            // arrange phase: create thing we want to test
            var sut = new LoanTerm(1);

            // no explicit act phase

            // assert phase
            Assert.That(sut.Years, Is.EqualTo(1));
        }

        [Test]
        public void RespectValueEquality()
        {
            // two reference types
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RespectValueInequality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void ReferenceEquality()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);

            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));

            var x = new List<string> { "a", "b" };
            var y = x;
            var z = new List<string> { "a", "b" };

            Assert.That(x, Is.SameAs(y));
            Assert.That(x, Is.Not.SameAs(z));
        }
    }
}
