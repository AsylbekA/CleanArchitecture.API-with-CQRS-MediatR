using CleanArhcitecture.Application.Features.ProductFetures.Commands;
using FluentValidation;

namespace CleanArhcitecture.Application.Features.ProductFetures.Validators;

public class CreateProductCommndValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommndValidator()
    {
        RuleFor(c => c.Barcode).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Price).ScalePrecision(2, 8);
    }
}
