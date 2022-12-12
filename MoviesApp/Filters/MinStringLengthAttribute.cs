using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class MinStringLengthAttribute : ValidationAttribute
    {
        public MinStringLengthAttribute(int minLength)
        {
            MinWordLength = minLength;
        }

        public int MinWordLength { get; }

        public string GetErrorMessage() =>
            $"This field must contain at least {MinWordLength} characters.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldLength = ((String) value).Length;

            if (fieldLength < MinWordLength)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}