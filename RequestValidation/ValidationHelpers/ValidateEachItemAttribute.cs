using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace RequestValidation.ValidationHelpers
{
    public class ValidateEachItemAttribute : ValidationAttribute
    {
        protected List<ValidationResult> results;

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null) return true;

            var isValid = true;
            foreach(var item in list)
            {
                results = new List<ValidationResult>();
                var isItemValid = Validator.TryValidateObject(item, new ValidationContext(item), null, true);
                isValid &= isItemValid;
            }
            return isValid;
        }
    }
}
