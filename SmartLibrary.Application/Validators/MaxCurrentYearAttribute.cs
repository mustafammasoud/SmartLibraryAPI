using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.Application.Validators;

public class MaxCurrentYearAttribute :ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if(value is not int year)
            return false;
        return year >=1 && year <= DateTime.Now.Year;
    } 
}