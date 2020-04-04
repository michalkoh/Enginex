using Enginex.Domain.Data;
using FluentValidation;

namespace Enginex.Application.Categories.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name.Slovak)
                .MaximumLength(40)
                .NotEmpty();

            RuleFor(c => c.Name.English)
                .MaximumLength(40)
                .NotEmpty();
        }
    }
}
