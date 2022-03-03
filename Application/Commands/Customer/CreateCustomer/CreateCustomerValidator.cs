using Domain.Record.Request.Customer;
using FluentValidation;

namespace Application.Commands.Customer.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(p => p.CustomerDTO.Email)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.CustomerDTO.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.CustomerDTO.PhoneNumber)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.CustomerDTO.State)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.CustomerDTO.LGA)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required");


    }
}
