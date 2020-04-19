using FluentValidation;

namespace Enginex.Application.Products.Commands
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(c => c.Name.Slovak)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Name.English)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Type)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(c => c.Description.Slovak)
                .MaximumLength(200);

            RuleFor(c => c.Description.English)
                .MaximumLength(2000);

            RuleFor(c => c.CategoryId)
                .NotEmpty();
        }
    }
}
