
using FluentValidation;

namespace OnlineShopCQRS.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(v => v.Title)
              .NotEmpty().WithMessage("Name is required.")
              .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            RuleFor(v => v.Description)
               .NotEmpty().WithMessage("Description is required.");

            RuleFor(v => v.Price)
               .GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(v => v.Qty)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative");
        }
    }
}
