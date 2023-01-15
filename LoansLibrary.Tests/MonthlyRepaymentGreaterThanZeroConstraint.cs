﻿using Loans.Domain.Applications;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansLibrary.Tests
{
    internal class MonthlyRepaymentGreaterThanZeroConstraint : Constraint
    {
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            // type cast
            MonthlyRepaymentComparison comparison = actual as MonthlyRepaymentComparison;

            if (comparison is null)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            }
        }
    }
}
