using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min3MonthsMovieDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var dateSinceReleased = DateTime.Now.Year - movie.DateAdded.Value.Year;
            return (dateSinceReleased > 1)
                ? ValidationResult.Success
                : new ValidationResult("Make this shit longer than a year");
        }
    }
}