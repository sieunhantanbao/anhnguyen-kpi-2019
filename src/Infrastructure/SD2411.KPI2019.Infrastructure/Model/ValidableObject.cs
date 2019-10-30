using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SD2411.KPI2019.Infrastructure.Model
{
    public class ValidableObject
    {
        public virtual bool IsValid()
        {
            return Validate().Count > 0;
        }
        public virtual IList<ValidationResult> Validate()
        {
            IList<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), results);
            return results;
        }
    }
}
