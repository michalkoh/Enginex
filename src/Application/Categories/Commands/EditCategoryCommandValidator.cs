using FluentValidation;

namespace Enginex.Application.Categories.Commands
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(c => c.Name.Slovak)
                .MaximumLength(40)
                .NotEmpty();

            RuleFor(c => c.Name.English)
                .MaximumLength(40)
                .NotEmpty();

            RuleFor(c => c.Order)
                .GreaterThanOrEqualTo((ushort)1)
                .LessThanOrEqualTo((ushort)999);
        }
    }
}
