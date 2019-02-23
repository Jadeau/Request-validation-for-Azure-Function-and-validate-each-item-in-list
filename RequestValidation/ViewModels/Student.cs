using System;
using System.ComponentModel.DataAnnotations;

namespace RequestValidation.ViewModels
{
    public class Student
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,100)]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
