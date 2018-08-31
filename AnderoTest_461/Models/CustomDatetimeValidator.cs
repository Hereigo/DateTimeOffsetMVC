using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AnderoTest_461.Models
{
	public class CustomDateTimeValidator : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult($"{validationContext.DisplayName} is required!");
			}
			else if (DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd HH:mm",
						  new CultureInfo("en-US"), DateTimeStyles.None, out DateTime myDate))
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult("Enter valid date and time!");
			}
		}
	}
}