using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(Type type, IList<ValidationResult> validationResults)
        {
            TargetType = type;
            ValidationResults = validationResults;
        }

        public Type TargetType { get; }

        public IList<ValidationResult> ValidationResults { get; }

        public override string Message
        {
            get
            {
                return string.Concat(TargetType.ToString(), ": ", string.Join(';', ValidationResults.Select(x => $"{x.ErrorMessage}")));
            }
        }
    }
}
