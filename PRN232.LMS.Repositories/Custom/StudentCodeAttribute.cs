using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PRN232.LMS.Services.Custom
{
    public class StudentCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string code = value.ToString().Trim();

            return Regex.IsMatch(code, @"^(SE|CE|AI)\d{6}$");
        }
    }

}