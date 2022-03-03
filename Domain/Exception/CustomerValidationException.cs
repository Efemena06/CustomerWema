using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Domain.Exception;

public class CustomerValidationException : ApplicationException
{
    public List<string> ValdationErrors { get; set; }

    public CustomerValidationException(ValidationResult validationResult)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }

    public CustomerValidationException(List<ValidationFailure> validationFailures)
    {
        ValdationErrors = new List<string>();
        foreach (var validationError in validationFailures)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}
