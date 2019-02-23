using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RequestValidation.ViewModels
{
    public class RequestBody<T>
    {
        public T Value { get; set; }
        public bool IsValid { get; set; }
        public List<ValidationResult> Errors { get; set; }
    }
}
