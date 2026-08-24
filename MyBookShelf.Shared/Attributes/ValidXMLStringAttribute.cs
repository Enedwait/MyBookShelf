using System;
using System.ComponentModel.DataAnnotations;
using MyBookShelf.Shared.Helpers;

namespace MyBookShelf.Shared.Attributes
{
    public sealed class ValidXMLStringAttribute : ValidationAttribute
    {
        #region IsValid

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            if (value is string text)
            {
                if (!text.IsValidXml(out Exception exception))
                    return new ValidationResult(exception.Message);

                return ValidationResult.Success;
            }

            return new ValidationResult($"The provided value is not {typeof(string)}!");
        }

        #endregion
    }
}
