using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RequestValidation.ValidationHelpers;

namespace RequestValidation.ViewModels
{
    public class Course
    {
        [Required]
        public string Name { get; set; }

        [ValidateEachItem]
        public List<Student> Students { get; set; }
    }
}
