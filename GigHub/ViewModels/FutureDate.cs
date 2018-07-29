using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string[] formats = {"M/d/yyyy", "MM/dd/yyyy", "d MMM yyyy"};
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                formats, 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out dateTime
            );
            return (isValid && dateTime > DateTime.Now);
        }
    }
}